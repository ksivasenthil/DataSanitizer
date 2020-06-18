using System;
using Xunit;

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
    }
}
