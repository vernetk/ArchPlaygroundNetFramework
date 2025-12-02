using CslaExemple.DalNetStandard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.DalEfNetStandard
{
    public class ResourceDal : IResourceDal
    {
        private readonly CslaDbContext db;

        public ResourceDal(CslaDbContext context)
        {
            db = context;
        }

        #region Mapping
        private ResourceDto EntityToDto(Resource entity)
        {
            ResourceDto result = new ResourceDto()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                LastChanged = entity.LastChanged
            };
            return result;
        }
        #endregion Mapping

        #region Query
        public ResourceDto Fetch(int id)
        {
            var query = (from r in db.Resources
                          where r.Id == id
                         select r).FirstOrDefault();
            if (query == null)
                throw new DataNotFoundException("Resource");
            return EntityToDto(query);
        }
        public List<ResourceDto> FetchList()
        {
            List<ResourceDto> result = new List<ResourceDto>();
            var query = from r in db.Resources
                        select r;

            result = query.ToList().ConvertAll(EntityToDto);
            return result;
        }
        public bool Exists(int id)
        {
            var result = (from r in db.Resources
                          where r.Id == id
                          select r.Id).Count() > 0;
            return result;
        }
        public int ExistsByFirstNameAndLastName(string firstName, string lastName)
        {
            var result = (from r in db.Resources
                          where r.FirstName == firstName && r.LastName == lastName
                          select r.Id)
                          .FirstOrDefault();
            return result;
        }

        #endregion Query

        #region Command
        public void Insert(ResourceDto item)
        {
            var newItem = new Resource
            {
                FirstName = item.FirstName,
                LastName = item.LastName
            };
            db.Resources.Add(newItem);
            db.SaveChanges();
            item.Id = newItem.Id;
            item.LastChanged = newItem.LastChanged;
        }
        public void Update(ResourceDto item)
        {
            var data = (from r in db.Resources
                        where r.Id == item.Id
                        select r).FirstOrDefault();
            if (data == null)
                throw new DataNotFoundException("Resource");
            if (!data.LastChanged.Matches(item.LastChanged))
                throw new ConcurrencyException("Resource");

            data.FirstName = item.FirstName;
            data.LastName = item.LastName;
            var count = db.SaveChanges();
            //if (count == 0)
            //  throw new UpdateFailureException("Resource");
            item.LastChanged = data.LastChanged;
        }
        public void Delete(int id)
        {
            var data = (from r in db.Resources
                        where r.Id == id
                        select r).FirstOrDefault();
            if (data != null)
            {
                db.Resources.Remove(data);
                db.SaveChanges();
            }
        }
        #endregion Command
    }
}
