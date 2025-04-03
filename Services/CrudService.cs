using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalExpensesApi.Data;
using PersonalExpensesApi.Interfaces;

namespace PersonalExpensesApi.Services;

public class CrudService<Entity, UpdateDto>
    where Entity : class, IBaseEntity
{
    protected readonly DbSet<Entity> _dbSet;

    protected AppDbContext Context { get; set; }

    protected readonly IMapper _mapper;

    public required IQueryable<Entity> QueryBuilder { get; set; }

    public CrudService(AppDbContext context, IMapper mapper)
    {
        Context = context;
        _dbSet = Context.Set<Entity>();
        _mapper = mapper;
        QueryBuilder = CreateQueryBuilder();
    }

    public Func<IQueryable<Entity>> CreateQueryBuilder => () => _dbSet.AsQueryable();

    public async Task CreateAsync(Entity dto)
    {
        Entity entity = _mapper.Map<Entity>(dto);

        _mapper.Map(dto, entity);

        _dbSet.Add(entity);

        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(string id, UpdateDto dto)
    {
        var item = await GetByIdAsync(id);

        _mapper.Map(dto, item);

        await Context.SaveChangesAsync();
    }

    public async Task<List<Entity>> ListAsync()
    {
        return await QueryBuilder.ToListAsync();
    }

    public async Task<Entity> GetByIdAsync(string id)
    {
        return await QueryBuilder.FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception();
    }

    public async Task DeleteByIdAsync(string id)
    {
        var registry = await GetByIdAsync(id);

        Context.Remove(registry);

        await Context.SaveChangesAsync();
    }
}
