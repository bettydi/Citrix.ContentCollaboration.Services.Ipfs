@Library(["pacman", "sharefile"]) _

ccc_pipelineDotNetDocker(
    kubernetes: [
        cloud: "jenkube",
        includeDocker: true,
        registry: "ci-local-docker.repo.citrite.net",
        containers: [
            docker: [image: 'dcind:latest-20210218103234', registry: 'ci-local-docker.repo.citrite.net', resourceRequestCpu: '2', resourceLimitCpu: '4', resourceRequestMemory: '2Gi', resourceLimitMemory: '4Gi'],
            zip: [image:'dotnet-sonar:2.2-sdk', resourceRequestCpu:'1', resourceLimitCpu:'2', resourceRequestMemory:'1Gi', resourceLimitMemory:'2Gi']
        ]
    ],
    dotnetVersion: "3.1"
)

