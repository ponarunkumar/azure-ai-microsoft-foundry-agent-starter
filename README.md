# Azure AI Microsoft Foundry Agent Starter Template

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-10.0-blue.svg)](https://dotnet.microsoft.com/)
[![Azure AI](https://img.shields.io/badge/Azure%20AI-Foundry-0078d4.svg)](https://azure.microsoft.com/en-us/products/ai-studio/)

> **🚀 Quick Start Template**: Bridge from Microsoft Foundry Playground to Production Code

This project demonstrates how to interact with Azure AI Foundry agents using the **Azure AI Projects SDK**. It provides a simple console application that connects to your Azure AI project and interacts with a deployed agent.

## 🎯 Perfect for

- **AI Engineers** transitioning from playground to production
- **Developers** new to Azure AI Foundry SDK  
- **Teams** wanting a standardized starting point
- **Anyone** building on Microsoft Foundry agents

## ⚡ Quick Start

1. **Use this template** - Click "Use this template" button above
2. **Configure** - Copy `AgentDemo/.env.example` to `AgentDemo/.env` and fill in your values
3. **Login** - Run `az login` in terminal
4. **Run** - Press `F5` in VS Code or run `dotnet run`

> 📖 Need help? See our [Step-by-Step Guide](STEP_BY_STEP_GUIDE.md)

## Project Structure

```
├── .vscode/                    # VS Code configuration
│   ├── launch.json            # Debug configuration for F5 debugging
│   └── tasks.json             # Build and run tasks (Ctrl+Shift+B)
├── AgentDemo/                 # Main project directory
│   ├── .env                   # Environment variables (your credentials)
│   ├── .env.example          # Template for environment variables
│   ├── .gitignore            # Git ignore file (protects .env from commits)
│   ├── AgentDemo.csproj      # .NET project file with package references
│   ├── Program.cs            # Main application code
│   ├── bin/                  # Build output directory
│   └── obj/                  # Build intermediate files
└── README.md                 # This documentation file
```

## File Descriptions

### Configuration Files

#### `.vscode/launch.json`
VS Code debugger configuration that enables F5 debugging. It:
- Runs the build task before launching
- Points to the compiled executable
- Uses the integrated terminal for output
- Sets the working directory to the AgentDemo folder

#### `.vscode/tasks.json`
VS Code task definitions for common operations:
- **build**: Compiles the project (`dotnet build`)
- **restore**: Restores NuGet packages (`dotnet restore`)
- **run**: Builds and runs the project (`dotnet run`)

Use `Ctrl+Shift+B` to access these tasks.

### Project Files

#### `AgentDemo/AgentDemo.csproj`
The .NET 10.0 console application project file containing:

**Target Framework**: .NET 10.0 with C# implicit usings and nullable reference types enabled

**NuGet Packages**:
- `Azure.AI.Projects` (1.2.0-beta.5) - Core Azure AI Projects SDK
- `Azure.AI.Projects.OpenAI` (1.0.0-beta.5) - OpenAI integration for agents
- `Azure.Identity` (1.*) - Azure authentication and credential management
- `DotNetEnv` (3.*) - Environment variable loading from .env files
- `OpenAI` (2.8.0) - OpenAI SDK for response handling

#### `AgentDemo/Program.cs`
The main application code that:
1. Loads environment variables from the `.env` file
2. Establishes connection to your Azure AI project using `DefaultAzureCredential`
3. Retrieves the specified agent by name
4. Creates a response client configured for that agent
5. Sends a message to the agent and displays the response

**Key Components**:
- Uses `AIProjectClient` to connect to Azure AI Foundry
- Retrieves `AgentRecord` information
- Creates `ProjectResponsesClient` for agent communication
- Handles `ResponseResult` and extracts text output

#### `AgentDemo/.env`
Contains your Azure AI Foundry configuration:

**Required Variables**:
- `AZURE_AI_PROJECT_ENDPOINT` - Your AI project endpoint URL
- `AZURE_AGENT_NAME` - Name of the agent to interact with

**Additional Variables** (populated from Azure deployment):
- `AZURE_EXISTING_AGENT_ID` - Full agent identifier with version
- `AZURE_ENV_NAME` - Environment name for deployment
- `AZURE_LOCATION` - Azure region
- `AZURE_SUBSCRIPTION_ID` - Your Azure subscription ID
- `AZURE_EXISTING_AIPROJECT_ENDPOINT` - Alternative project endpoint
- `AZURE_EXISTING_AIPROJECT_RESOURCE_ID` - Full resource ID for the AI project
- `AZURE_EXISTING_RESOURCE_ID` - Parent resource ID
- `AZD_ALLOW_NON_EMPTY_FOLDER` - Azure Developer CLI setting

⚠️ **Security**: This file contains sensitive information and is excluded from Git via `.gitignore`

#### `AgentDemo/.env.example`
Template file showing the structure of required environment variables. Safe to commit to version control as it contains no sensitive data.

#### `AgentDemo/.gitignore`
Prevents sensitive and build-generated files from being committed:
- `.env` files (contain credentials)
- Build outputs (`bin/`, `obj/`)
- User-specific files
- IDE-specific files

## Getting Started

### Prerequisites
- **Microsoft Foundry Agent**: Create and deploy an agent in [Microsoft Foundry Playground](https://ai.azure.com) first
- **.NET 10.0 SDK** (or compatible version available in your environment)
- **Azure CLI** (required for authentication)
- **Environment Configuration**: Access to your Azure AI Foundry project endpoint and agent name for the `.env` file

> **Note**: If Azure CLI is not installed, you can install it using:
> ```bash
> # On Ubuntu/Debian
> curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash
> ```

### Setup
1. **Clone/Download** this project
2. **Configure environment**: Update `AgentDemo/.env` with your values (if not already done)
3. **Login to Azure**: Run `az login` in terminal
4. **Install dependencies**: `dotnet restore` (or build will do this automatically)

### Running the Application

**Option 1: VS Code Debug (Recommended)**
- Press `F5` to build and run with debugging

**Option 2: Command Line**
```bash
cd AgentDemo
dotnet run
```

**Option 3: VS Code Tasks**
- Press `Ctrl+Shift+B` and select "run"

### Expected Output
```
Connecting to project: https://ms-prj-foundry-poc-demo-9924-res.services.ai.azure.com/api/projects/ms-prj-foundry-poc-demo-9924
Using agent: wholesale-broker-construction-demo-assist
Agent retrieved (name: wholesale-broker-construction-demo-assist, id: wholesale-broker-construction-demo-assist)
Sure! Here's a construction-themed joke for you:

Why did the demolition contractor always carry a pencil behind his ear?
Because he wanted to draw a line before breaking the rules!

Let me know if you have any insurance or construction-related questions—I'm here to help!
```

## Authentication

The application uses `DefaultAzureCredential` which attempts authentication in this order:
1. Environment variables (service principal)
2. Managed identity (if running in Azure)
3. Azure CLI credentials (`az login`)
4. Visual Studio credentials
5. VS Code credentials

For local development, ensure you've run `az login` before running the application.

## Troubleshooting

**Build Errors**
- Ensure .NET 10.0 SDK (or compatible version) is installed
- If targeting wrong .NET version, update `TargetFramework` in `.csproj` to match your environment
- Run `dotnet restore` to install packages

**Authentication Errors**
- Install Azure CLI if not available: `curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash`
- Run `az login --use-device-code` for authentication in environments without browser access
- Ensure you have access to the Azure subscription and AI project
- Verify your credentials have the necessary permissions for the AI project

**Runtime Errors**
- If you get "Framework not found" errors, check available .NET versions with `dotnet --list-runtimes`
- Update the `TargetFramework` in `AgentDemo.csproj` to match an available version

**Agent Not Found**
- Check the `AZURE_AGENT_NAME` in your `.env` file
- Ensure the agent exists in your Azure AI Foundry project

**Connection Errors**
- Verify the `AZURE_AI_PROJECT_ENDPOINT` URL is correct
- Check your network connection and firewall settings

## Development

This project is set up for Azure AI Foundry development using the Azure AI Projects SDK with:
- Proper error handling and environment variable validation
- Clean separation of configuration from code
- VS Code integration for debugging and tasks
- Security best practices (credentials in environment variables)

You can extend this foundation by:
- Adding more complex conversations
- Implementing streaming responses
- Adding custom tools and functions
- Integrating with other Azure AI services

## 📋 Template Usage

### Using This Template
1. Click **"Use this template"** button at the top of this repository
2. Create your new repository from this template
3. Clone your new repository locally
4. Follow the **Quick Start** steps above

### What You Get
- ✅ Complete working Azure AI Foundry agent client
- ✅ VS Code debugging configuration (F5 to run)
- ✅ Environment-based configuration with security
- ✅ Comprehensive documentation and guides
- ✅ Production-ready error handling and authentication

## 🤝 Contributing

We welcome contributions! Please see our [Contributing Guide](CONTRIBUTING.md) for details.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🔒 Security

For security considerations and reporting vulnerabilities, please see our [Security Policy](SECURITY.md).