#!/bin/bash

VERSION=$(cat version.txt)
IMAGE_TAG="helloaks:$VERSION"

sudo docker build -t $IMAGE_TAG .
