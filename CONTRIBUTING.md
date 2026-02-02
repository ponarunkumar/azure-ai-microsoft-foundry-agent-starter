# Contributing to Azure AI Microsoft Foundry Agent Starter Template

Thank you for your interest in contributing! This template is designed to help developers transition from Microsoft Foundry playground to production code.

## How to Contribute

### 🐛 Bug Reports
- Use GitHub Issues to report bugs
- Include your environment details (.NET version, OS, etc.)
- Provide steps to reproduce the issue

### 💡 Feature Requests  
- Use GitHub Issues for feature requests
- Explain the use case and how it would help template users
- Consider backward compatibility

### 🔧 Pull Requests
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Test thoroughly
5. Update documentation if needed
6. Commit with clear messages
7. Push to your fork
8. Create a Pull Request

### 🔒 Security
- Never commit real credentials or sensitive data
- Always use template values in `.env` files
- Update `.gitignore` if adding new file types

### 📝 Documentation
- Keep README.md up to date
- Update STEP_BY_STEP_GUIDE.md if changing the workflow
- Comment your code clearly

### ✅ Code Standards
- Follow existing code patterns
- Use meaningful variable names
- Include error handling
- Test with real Azure AI Foundry projects

## Development Setup

1. Clone your fork
2. Copy `AgentDemo/.env.example` to `AgentDemo/.env`
3. Fill in your Azure AI Foundry details
4. Run `dotnet restore` in AgentDemo folder
5. Test with `dotnet run`

Thank you for helping make this template better for the community! 🚀