using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.AI.Embeddings;
using Simple.SemanticKernel.Connectors.Gradio;

public class Program
{
    public  static async Task Main(string[] args)
    {
        var builder = new KernelBuilder();
        builder.WithGradioEmbeddingGenerationService("https://alexkhcheung-embeddingtest.hf.space/", 0, setAsDefault: true);
        var kernel = builder.Build();
        var embeddingGeneration = kernel.GetService<ITextEmbeddingGeneration>();
        var embedding = await embeddingGeneration.GenerateEmbeddingsAsync(new List<String>() { "Hello World !" });
        Console.WriteLine(embedding[0]);
    }
}