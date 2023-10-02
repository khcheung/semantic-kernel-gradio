using Microsoft.SemanticKernel.AI.Embeddings;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.SemanticKernel.Connectors.Gradio
{
    public class SimpleGradioTextEmbeddingGeneration : ITextEmbeddingGeneration
    {
        private readonly String mEndPoint = null!;
        private readonly int mFnIndex = -1;
        private Simple.GradioClient.Client mClient = null!;

        public SimpleGradioTextEmbeddingGeneration(String endpoint, Int32 fnIndex)
        {
            this.mEndPoint = endpoint;
            this.mFnIndex = fnIndex;
        }

        private Simple.GradioClient.Client GetClient()
        {
            this.mClient ??= new GradioClient.Client(new Uri(mEndPoint));
            return this.mClient;
        }

        public async Task<IList<ReadOnlyMemory<float>>> GenerateEmbeddingsAsync(IList<string> data, CancellationToken cancellationToken = default)
        {
            var result = new List<ReadOnlyMemory<float>>();
            var client = this.GetClient();

            foreach (var d in data)
            {
                var embedding = await client.PredictAsync<float[]>(mFnIndex, d);
                result.Add(new ReadOnlyMemory<float>(embedding));
            }
            return result;
        }
    }
}
