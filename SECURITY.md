# Security Policy

## Supported Versions

This template uses the latest stable versions of Azure AI Projects SDK and related packages. We support the current version and encourage keeping dependencies up to date.

## Reporting a Vulnerability

If you discover a security vulnerability in this template, please report it by:

1. **DO NOT** create a public GitHub issue
2. Send an email to the repository maintainer with details
3. Include steps to reproduce if applicable
4. Allow time for investigation and fix

## Security Best Practices

This template follows security best practices:

### ✅ What We Do
- Use environment variables for all sensitive data
- Comprehensive `.gitignore` to prevent credential commits
- Template values only in committed `.env` files
- Azure Identity library for secure authentication
- No hardcoded secrets or credentials

### 🔒 What You Should Do
1. **Never commit real credentials** - Always use `.env` files
2. **Keep dependencies updated** - Run `dotnet outdated` regularly  
3. **Use least-privilege access** - Only grant necessary Azure permissions
4. **Review `.gitignore`** - Ensure it covers all sensitive files
5. **Rotate credentials** - Regularly update Azure keys/tokens

### ⚠️ Common Risks to Avoid
- Committing `.env` files with real values
- Hardcoding connection strings in source code
- Using overly permissive Azure role assignments
- Sharing logs that might contain sensitive data

### 🛡️ Azure Security
- Use Azure CLI authentication for development
- Implement proper role-based access control (RBAC)
- Monitor Azure Activity Logs for unusual access
- Consider using Azure Key Vault for production secrets

## Updates

Security updates to this template will be documented in GitHub releases with appropriate tags and descriptions.