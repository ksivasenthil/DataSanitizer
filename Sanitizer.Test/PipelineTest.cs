using System;
using Xunit;
using Sanitizer;

namespace Sanitizer.Test
{
    public class PipelineTest
    {
        [Fact]
        public void CallAllHandlersSequentially()
        {
            //TODO: All calls to the handlers should succeed.
        }

        [Fact]
        public void AbortEntirePipelineOnFailure()
        {
            //TODO: On failure no subsequent processing should be performed.
        }

        [Fact]
        public void ResultOfAllHandlersAreAvailable()
        {
            //TODO: Each handler result should be captured and appended one after another.
        }

        [Fact]
        public void PipelineResultIsAsExpected()
        {
            //TODO: Pipeline has processed the result appropriately.
        }
    }
}
