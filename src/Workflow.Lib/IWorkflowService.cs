using WorkflowCore;
using WorkflowCore.Services.DefinitionStorage;

namespace Workflow.Lib
{
    public interface IWorkflowService
    {
        IWorkflowService AddWorkflowJson(string definition);
    }
}
