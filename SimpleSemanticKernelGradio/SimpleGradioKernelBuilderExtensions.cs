using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.AI.Embeddings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.SemanticKernel.Connectors.Gradio
{
    public static class SimpleGradioKernelBuilderExtensions
    {
        public static KernelBuilder WithGradioEmbeddingGenerationService(this KernelBuilder builder,
            string endpoint,
            Int32 fnIndex,
           string? serviceId = null,
           bool setAsDefault = false)
        {
            builder.WithAIService<ITextEmbeddingGeneration>(serviceId,
                (parameters) => new SimpleGradioTextEmbeddingGeneration(endpoint, fnIndex),
                setAsDefault);
            return builder;
        }
    }


}
