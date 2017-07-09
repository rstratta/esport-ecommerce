using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public interface IFieldRepository : IRepository<Field>
    {
        List<Field> GetAllActiveFields();
        Field GetFieldByName(string fieldName);

    }
}
