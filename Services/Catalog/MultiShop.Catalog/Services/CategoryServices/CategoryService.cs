using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categories;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);   //Bağlantı client nesnesine atandı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);  // client sayesinde veritabanına gittik.
            _categories = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);   //Burda da tabloya ulaştık
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categories.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categories.DeleteOneAsync(x=>x.CategoryId == id);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categories.Find<Category>(x=>x.CategoryId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categories.Find(x=> true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categories.FindOneAndReplaceAsync(x=>x.CategoryId == updateCategoryDto.CategoryId, values);
        }
    }
}
