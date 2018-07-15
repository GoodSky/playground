#!/bin/bash

SERVICE_URL="http://localhost:5000"
# SERVICE_URL="http://goodaks.westus2.cloudapp.azure.com:6637"

print_header() {
    echo ""
    echo ""
    echo "-------------------------------------------------"
    echo "   RUN: $1"
    echo "-------------------------------------------------"
}

get_all() {
    URL="$SERVICE_URL/api/data"
    print_header "GET $URL"
    curl -i $URL
}

get_data() {
    URL="$SERVICE_URL/api/data/$1"
    print_header "GET $URL"
    curl -i $URL
}

put_data() {
    URL="$SERVICE_URL/api/data/$1"
    print_header "PUT $URL"
    curl -i -X PUT -H "content-type:application/json" $URL -d '{ Data: "'"$2"'" }'
}

delete_data() {
    URL="$SERVICE_URL/api/data/$1"
    print_header "DELETE $URL"
    curl -i -X DELETE $URL
}

get_all
put_data 'foo' 'Foo Data!!!'
get_all
put_data 'bar' 'Bar Data???'
get_all
get_data 'foo'
delete_data 'bar'
get_all

echo ""
