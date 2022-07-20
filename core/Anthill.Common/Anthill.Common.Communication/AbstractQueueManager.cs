using Anthill.Common.Communication.Contracts;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Anthill.Common.Communication
{
    public abstract class AbstractQueueManager : IQueueManager
    {
        private CloudQueue _queue;
        private CloudQueueClient _queueClient;
        private CloudStorageAccount _storageAccount;

        public AbstractQueueManager(string queueName, string connectionString)
        {
            _storageAccount = CloudStorageAccount.Parse(connectionString);
            _queueClient = _storageAccount.CreateCloudQueueClient();
            _queue = _queueClient.GetQueueReference(queueName);
        }

        public async Task EnusureQueueCreated()
        {
            await _queue.CreateIfNotExistsAsync();
        }

        public async Task ClearQueue()
        {
            await _queue.ClearAsync();
        }

        protected async Task EnqueueEvent<T>(T @event)
        {
            await _queue.AddMessageAsync(new CloudQueueMessage(JsonConvert.SerializeObject(@event)));
        }
    }
}
