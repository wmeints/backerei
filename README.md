# Backerei sample application

This is my personal demo application to test things like domain driven design,
microservices, micro frontends, and other hip and happening stuff.

The demo application explores an online bakery scenario for a german bakery that
sells freshly baked pies and cakes. 

Feel free to explore the solution and see how I approach things.

## Current noteworthy features

* Dapr - Testing out the Dapr building blocks
* Kubernetes - Deploying the microservices and frontend to AKS/Kubernetes
* Arc42 - Documenting architecture decisions in a well thought out format

## Quickstart 

You can deploy this solution using docker-compose or Kubernetes.
For Kubernetes, run the following command:

```
./deploy-kubernetes.ps1
```

For docker-compose, use the following command:

```
./deploy-compose.ps1
```

## Documentation

There are two forms of documentation for the solution: 

* `docs/engineering` - Contains the engineering decisions and design.
* `docs/functional` - Describes the functionality of the application.

