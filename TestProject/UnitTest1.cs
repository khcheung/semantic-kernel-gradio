using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.AI.Embeddings;
using Simple.SemanticKernel.Connectors.Gradio;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestEmbedding()
        {
            var builder = new KernelBuilder();
            builder.WithGradioEmbeddingGenerationService("https://alexkhcheung-embeddingtest.hf.space/", 0, setAsDefault: true);
            var kernel = builder.Build();
            var embeddingGeneration = kernel.GetService<ITextEmbeddingGeneration>();
            var embedding = await embeddingGeneration.GenerateEmbeddingsAsync(new List<String>() { "Hello World !" });
            //Console.WriteLine(embedding[0]);
            Assert.AreEqual(1, embedding.Count);
            Assert.AreEqual(384, embedding[0].Length);
        }
    }
}