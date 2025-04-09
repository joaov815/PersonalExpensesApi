using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalExpensesApi.Data;
using PersonalExpensesApi.Interfaces;
using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Services;

public class CrudService<Entity, CreateDto, UpdateDto>
    where Entity : class, IBaseEntity
{
    protected readonly DbSet<Entity> _dbSet;

    protected AppDbContext Context { get; set; }

    protected readonly IMapper _mapper;

    private readonly bool _entityHasAccount = false;

    public required IQueryable<Entity> QueryBuilder { get; set; }

    public CrudService(AppDbContext context, IMapper mapper, bool entityHasAccount = false)
    {
        Context = context;
        _dbSet = Context.Set<Entity>();
        _mapper = mapper;
        QueryBuilder = CreateQueryBuilder();
        _entityHasAccount = entityHasAccount;
    }

    public Func<IQueryable<Entity>> CreateQueryBuilder => () => _dbSet.AsQueryable();

    public virtual async Task CreateAsync(CreateDto dto, Account account)
    {
        Entity entity = _mapper.Map<Entity>(dto);

        if (_entityHasAccount)
        {
            ((IWithAccountEntity)entity).AccountId = account.Id;
        }

        _mapper.Map(dto, entity);

        _dbSet.Add(entity);

        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(string id, UpdateDto dto, Account account)
    {
        var item = await GetByIdAsync(id, account);

        _mapper.Map(dto, item);

        await Context.SaveChangesAsync();
    }

    public virtual async Task<List<Entity>> ListAsync(Account account)
    {
        return await QueryBuilder.ToListAsync();
    }

    public async Task<Entity> GetByIdAsync(string id, Account account)
    {
        var query = QueryBuilder;


        if (_entityHasAccount)
        {
            QueryBuilder.Where(_ => ((IWithAccountEntity)_).AccountId == account.Id);
        }

        return await QueryBuilder.FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception();
    }

    public async Task DeleteByIdAsync(string id, Account account)
    {
        var registry = await GetByIdAsync(id, account);

        Context.Remove(registry);

        await Context.SaveChangesAsync();
    }
}
