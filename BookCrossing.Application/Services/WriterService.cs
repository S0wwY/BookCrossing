using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Application.Interfaces;
using BookCrossing.Data.Interfaces;
using BookCrossing.Models;

namespace BookCrossing.Application.Services
{
    public class WriterService : IWriterService
    {
        private readonly IWriterRepository _writerRepository;

        public WriterService(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        public async Task AddWriterAsync(Writer newWriter)
        {
            _writerRepository.Insert(newWriter);
            await _writerRepository.SaveAsync();
        }

        public async Task DeleteWriterAsync(int writerId)
        {
            var writerToDelete = await _writerRepository.GetByIdAsync(writerId);

            _writerRepository.Delete(writerToDelete);
            await _writerRepository.SaveAsync();
        }

        public async Task<Writer> GetWriterByIdAsync(int writerId)
        {
            var writer = await _writerRepository.GetByIdAsync(writerId);
            return writer;
        }

        public async Task UpdateWriterAsync(Writer updateWriter)
        {
            var writer = await _writerRepository.GetByIdAsync(updateWriter.Id);

            writer.FullName = updateWriter.FullName;

            _writerRepository.Update(writer);
            await _writerRepository.SaveAsync();
        }
    }
}
