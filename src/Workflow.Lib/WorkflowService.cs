/**
 *  Uses WorkflowCore DefinitionStorage and Json definitions to store flexible workflows
 *  https://workflow-core.readthedocs.io/en/latest/json-yaml/
 */
using Newtonsoft.Json;
using WorkflowCore;
using WorkflowCore.Services;
using WorkflowCore.Services.DefinitionStorage;
using WorkflowCore.Interface;

namespace Workflow.Lib
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IDefinitionLoader _definitionLoader;
        public WorkflowService(IDefinitionLoader definitionLoader) {
            _definitionLoader = definitionLoader;
        }

        public IWorkflowService AddWorkflowJson(string definition) {
            _definitionLoader.LoadDefinition(definition, Deserializers.Json);

            return this;
        }
    }
}
