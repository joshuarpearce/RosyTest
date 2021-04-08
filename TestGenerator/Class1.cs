using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace TestGenerator
{
    [Generator]
    public class TestGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var sourceBuilder = new StringBuilder();

            sourceBuilder.Append($@"
                using System;

                namespace PostCompilation
                {{
                    class PostCompiledClass
                    {{
                        public static void PrintCrap()
                        {{
                            Console.WriteLine(""It Worked!"");
                        }}
                    }}
                }}
            ");

            context.AddSource("test", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        void ISourceGenerator.Initialize(GeneratorInitializationContext context)
        {
            // nothing to do
        }
    }
}
