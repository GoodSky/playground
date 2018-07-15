#!/bin/bash

VERSION=$(cat version.txt)
IMAGE_TAG="helloaks:$VERSION"

ACR_NAME="goodacr"
ACR_URL="$ACR_NAME.azurecr.io"
IMAGE_URL="$ACR_URL/$IMAGE_TAG"

sudo az acr login -n $ACR_NAME

sudo docker tag $IMAGE_TAG $IMAGE_URL
sudo docker push $IMAGE_URL
