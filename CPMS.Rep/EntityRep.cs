using System;
using System.Collections.Generic;
using Common.Methods;
using CPMS.BL;
using CPMS.BL.Interface;
using CPMS.Data;

namespace CPMS.Rep
{
    public class EntityRep : IEntity
    {
        private readonly EntityData entityData;

        public EntityRep()
        {
            entityData = new EntityData();
        }

        public OperationResult Save(Entity data)
        {
            var result = entityData.Save(data);
            return result;
        }

        public OperationResult GetInfo_ByID(int Id, out Entity data)
        {
            var result = entityData.GetInfo_ByID(Id, out data);
            return result;
        }

        public OperationResult GetAll(out List<Entity> datalist)
        {
            var result = entityData.GetAll(out datalist);
            return result;
        }

        public OperationResult DeleteInfoByIDNo(int Id)
        {
            var result = entityData.DeleteInfoByIDNo(Id);
            return result;
        }
    }
}
