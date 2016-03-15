using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using HtmlAgilityPack;
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
            Mapper.CreateMap<Record, RecordDTO>();
            var recordDto = Mapper.Map<Record, RecordDTO>(record);

            return recordDto;
        }

        public void Add(RecordDTO recordDto)
        {
            Mapper.CreateMap<RecordDTO, Record>();
            var record = Mapper.Map<RecordDTO, Record>(recordDto);
            _repository.Add(record);
        }

        private string GetHistoryUrl(string inputUrl)
        {
            string url = inputUrl;
            string keyWord = url.Substring(url.LastIndexOf("/") + 1);
            string outputUrl = "https://ru.wikipedia.org/w/index.php?title=" + keyWord + "&action=history";
            return outputUrl;
        }

        private string GetHistoryText(string historyUrl)
        {
            string searchString = "//div[@id='mw-content-text']";

            HtmlWeb web = new HtmlWeb();
            var page = web.Load(historyUrl);

            HtmlNode historyPageContent = page.DocumentNode.SelectSingleNode(searchString);

            return historyPageContent.InnerText;
        }

        private string GetHeader(string historyUrl)
        {
            string searchString = "//h1[@id='firstHeading']";

            HtmlWeb web = new HtmlWeb();
            var page = web.Load(historyUrl);

            HtmlNode headerContent = page.DocumentNode.SelectSingleNode(searchString);
            string replace = headerContent.InnerText.Replace(" — история изменений", "");
            var header = replace.Replace("Index.php?title=", "");

            return header;
        }

        private int GetNumberOfMaches(string text, string word)
        {
            int numberOfMaches = Regex.Matches(text, word).Count;

            return numberOfMaches;
        }

        public RecordDTO RateArticle(string url)
        {
            var record = new RecordDTO();

            string historyUrl = GetHistoryUrl(url);
            string historyText = GetHistoryText(historyUrl);
            string header = GetHeader(historyUrl);
            string word = "отпатрулирована";
            int mathes = GetNumberOfMaches(historyText, word);
            double result = mathes * 100 / 50;

            record.Result = result.ToString();
            record.Url = url;
            record.Header = header;
            record.Date = DateTime.Now;

            return record;
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
