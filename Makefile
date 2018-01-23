ORGANIZATION=alextanhongpin
REPOSITORY=dotnet-test
DOCKER_IMAGE=${ORGANIZATION}/${REPOSITORY}

dockerize:
	docker build -t ${DOCKER_IMAGE} .

run:
	docker run -p 5000:80 ${DOCKER_IMAGE}