# semantic-kernel-gradio

Using Gradio API for Semantic Kernel - TextEmbeddingGeneration

## Testing Embedding Service
Url: https://alexkhcheung-embeddingtest.hf.space/

## Embedding Sevice (Python)
```python
import gradio as gr
from sentence_transformers import SentenceTransformer
import json

model = SentenceTransformer("sentence-transformers/all-MiniLM-L6-v2")

def embedding(input):
    embeddings = model.encode(input)    
    yield json.dumps(embeddings.tolist())


with gr.Blocks() as iface:    
    with gr.Row():
        inp = gr.Textbox(placeholder="Embedding Vector")
        out = gr.Textbox()
    btn = gr.Button("Run")
    btn.click(fn=embedding, inputs=inp, outputs=out, api_name="embedding")         

iface.queue().launch()
```

## Sample Use Gradio API for Embedding
```csharp
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
```