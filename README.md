# Citrix.ContentCollaboration.Services.Ipfs
A .Net microservice for pushing files from Citrix ShareFile to an IPFS daemon.

## Requirements
Requires local running IPFS deamon such as [go-ipfs](https://github.com/ipfs/go-ipfs). 
For all options, refer to [install IPFS](https://ipfs.io/#install) guide.

## Startup
1. Sart IPFS daemon
2. Run microservice 

To start/stop ipfs-go daemon from CLI:
```
ipfs daemon
ipfs shutdown
```

Confirm the microservice is rrunning: 
```
http://localhost:5100/service/ipfs/status
```

## third-party libraries

[Ipfs.Http.Client](https://www.nuget.org/packages/Ipfs.Http.Client/): provides .Net client access to the InterPlanetary File System


## API documentation
Local defaults: http://localhost:5100
```
http://{host}:{port}/service/ipfs/swagger/index.html
http://{host}:{port}/service/ipfs/swagger/v1/swagger.json
```

## Status
```
http://{host}:{port}/service/ipfs/status
```
