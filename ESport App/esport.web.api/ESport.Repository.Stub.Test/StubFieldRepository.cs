using ESport.Data.Entities;
using System.Collections.Generic;

namespace ESport.Repository.Stub.Test
{
    public class StubFieldRepository : IFieldRepository
    {
        Field currentField;
        public void AddEntity(Field entity)
        {
            if (currentField != null && currentField.Equals(entity))
            {
                throw new RepositoryException("El producto ya existe");
            }
            else
            {
                currentField = entity;
            }
        }

        public List<Field> GetAllActiveFields()
        {
            return GetAllEntities();
        }

        public List<Field> GetAllEntities()
        {
            List<Field> result = new List<Field>();
            if (currentField != null)
            {
                result.Add(currentField);
            }
            return result;
        }

        public Field GetFieldByName(string fieldName)
        {
            if(currentField!=null && currentField.Name.Equals(fieldName))
            {
                return currentField;
            }else
            {
                throw new RepositoryException("No se encontro el campo");
            }
        }

        public void RemoveEntity(Field entity)
        {
            throw new RepositoryException("Operación no permitida");
        }

        public void UpdateEntity(Field entity)
        {
            throw new RepositoryException("Operacion no permitida");
        }
    }
}
