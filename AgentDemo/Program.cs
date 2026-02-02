// Azure AI Foundry Agent Demo
// Using Azure.AI.Projects SDK for Agent interactions
using Azure.AI.Projects;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using OpenAI.Responses;

#pragma warning disable OPENAI001
#pragma warning disable CA2252

// Load environment variables from .env file
DotNetEnv.Env.Load();

// Read configuration from environment variables
string projectEndpoint = Environment.GetEnvironmentVariable("AZURE_AI_PROJECT_ENDPOINT") 
    ?? throw new InvalidOperationException("AZURE_AI_PROJECT_ENDPOINT environment variable is not set");
string agentName = Environment.GetEnvironmentVariable("AZURE_AGENT_NAME") 
    ?? throw new InvalidOperationException("AZURE_AGENT_NAME environment variable is not set");

Console.WriteLine($"Connecting to project: {projectEndpoint}");
Console.WriteLine($"Using agent: {agentName}");

// Connect to your project using the endpoint from your project page
// The DefaultAzureCredential will use your logged-in Azure CLI identity, make sure to run `az login` first
AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());

// Get the agent record by name
AgentRecord agentRecord = projectClient.Agents.GetAgent(agentName);
Console.WriteLine($"Agent retrieved (name: {agentRecord.Name}, id: {agentRecord.Id})");

// Get the responses client configured for this agent
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(
    new AgentReference(agentRecord.Name, agentRecord.Versions.Latest.Version));

// Use the agent to generate a response
ResponseResult response = responseClient.CreateResponse("Hello! Tell me a joke.");

Console.WriteLine(response.GetOutputText());
