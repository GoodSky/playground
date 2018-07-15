#!/bin/bash

VERSION=$(cat version.txt)
IMAGE_TAG="helloaks:$VERSION"

sudo docker run --rm --name hello -p 5000:80 $IMAGE_TAG
