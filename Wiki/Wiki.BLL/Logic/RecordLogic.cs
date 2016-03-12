using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Wiki.BLL.DTO;
using Wiki.BLL.Interfaces;
using Wiki.DAL.Entities;
using Wiki.DAL.Interfaces;

namespace Wiki.BLL.Logic
{
    public class RecordLogic : IRecordLogic
    {
        private readonly IRepository<Record> _repository;

        public RecordLogic(IRepository<Record> repository)
        {
            _repository = repository;
        }

        public IEnumerable<RecordDTO> GetAll()
        {
            var records = _repository.GetAll().ToList();

            Mapper.CreateMap<Record, RecordDTO>();
            var recordsDto = Mapper.Map<IEnumerable<Record>, IEnumerable<RecordDTO>>(records);
            return recordsDto;
        }

        public RecordDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("id null");
            }

            var record = _repository.Get(id.Value);
            var recordDto = Mapper.Map<Record, RecordDTO>(record);

            return recordDto;
        }

        public void Add(RecordDTO recordDto)
        {
            Mapper.CreateMap<RecordDTO, Record>();
            var record = Mapper.Map<RecordDTO, Record>(recordDto);
            _repository.Add(record);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Edit(RecordDTO recordDto)
        {
            var record = Mapper.Map<RecordDTO, Record>(recordDto);
            _repository.Edit(record);
        }
    }
}
