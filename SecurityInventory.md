- [Regional Deployment](#regional-deployment)
- [Log classes](#log-classes)
  - [Applicable log classes - refer Appendix Log classes](#applicable-log-classes---refer-appendix-log-classes)
    - [Dashboards (optional)](#dashboards-optional)
    - [Security key events (optional)](#security-key-events-optional)
    - [Other details (optional)](#other-details-optional)
- [Credential stores](#credential-stores)
- [Certificate classes](#certificate-classes)
- [Secret types](#secret-types)
  - [Applicable Secret types - refer Appendix Secret types](#applicable-secret-types---refer-appendix-secret-types)
    - [Other details you may want to include per secret type (optional)](#other-details-you-may-want-to-include-per-secret-type-optional)
- [Source code index](#source-code-index)
  - [Notable code](#notable-code)
- [Networking in general](#networking-in-general)
  - [Networking](#networking)
- [Credential attack surfaces](#credential-attack-surfaces)
- [Appendix](#appendix)
  - [Security key events](#security-key-events)
  - [Default security logging](#default-security-logging)
  - [Log classes](#log-classes-1)
  - [Secret types](#secret-types-1)

# Regional Deployment
* **Cloud Platform**:
* **Regions**:

# Log classes

## Applicable log classes - refer Appendix [Log classes](#log-classes-1)
* **Description**:
* **Source**:
* **Destination**:
* **How used today?**:
* **Interesting to security?**: Yes/No (*security key events*, *default security logging*) refer - Appendix [Security key events](#security-key-events-1), [Default security logging](#default-security-logging)
* **Example query**:
* **Access**:

### Dashboards (optional)
  * Dashboard links if any

### Security key events (optional)
* Applicable *security key events* - refer Appendix [Security key events](#security-key-events-1)
  * **Example query**:

### Other details (optional)
* Any other simple information like `Is App Log Level Configurable?`, `Log template`, `Log retention`, `Log time sync` etc.

# Credential stores
Details on how customer credentials are stored, if not explicitly state it.

# Certificate classes
Details on certificate monitoring, rotation etc.

# Secret types

## Applicable Secret types - refer Appendix [Secret types](#secret-types-1)
* **Description**:
* **How stored?**:
* **How generated?**:
* **Build/Runtime**:
* **Auto-rotation**:
* **Crash rotation time**:
* **Audited access**:
* **Risk factors**:

### Other details you may want to include per secret type (optional)

# Source code index

## Notable code
* List of notable code links (ex: link to api code, library code etc.)

# Networking in general

## Networking
* **Type of traffic**:
* **Backend service that handles the traffic**:
* **Current Public IP addresses**:
* **Deployment diagram**:

# Credential attack surfaces
* List of attack surfaces if any, if not explicitly state it.

# Appendix

## Security key events
- System and services startup and shutdown
- User (& admin) login (and logoff or session timeout where applicable)
- User (& admin) login failure
- Account creation, deletion, and modification
- Privilege assignment, revocation, and modification
- System error and alert messages
- Software installation, removal, or updates
- Unexpected failure to decrypt data
- Unexpected checksum mismatch

## Default security logging
- Web requests & responses in default format for your web/app server
- OS
- Web servers
- PaaS services
- Frameworks
- Security agents
- FaaS

## Log classes
- App Logs
- Server Logs
- PaaS Logs
- FaaS Logs
- ELB Access Logs
- VPC Flow Logs
- System Logs
- Logs for any other relevant sub systems

## Secret types
- Paas API Secrets
- Faas API Secrets
- Service-to-Service
- SSH keys
- OAuth tokens
- Any other relevant secret type
