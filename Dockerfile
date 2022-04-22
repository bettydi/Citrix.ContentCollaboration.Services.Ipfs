# Copyright © Citrix Systems, Inc.  All rights reserved.

# Build runtime image
FROM ctx-remote-docker-mcr.repo.citrite.net/dotnet/aspnet:3.1
WORKDIR /App
COPY /src/Ipfs/out .
# Unset ASPNETCORE_URLS to remove a warning that these URLs are being overridden
ENV ASPNETCORE_URLS=""
ENTRYPOINT ["dotnet", "Citrix.ContentCollaboration.Services.Ipfs.dll"]