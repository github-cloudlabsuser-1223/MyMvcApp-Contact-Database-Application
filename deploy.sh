#!/bin/bash

# Variables
RESOURCE_GROUP="GitHub-Copilot-Challenges"
LOCATION="Canada Central"
TEMPLATE_FILE="../templates/mainTemplate.json"
PARAMETERS_FILE="../templates/parameters.json"

# Create resource group
az group create --name $RESOURCE_GROUP --location $LOCATION

# Deploy the ARM template
az deployment group create --resource-group $RESOURCE_GROUP --template-file $TEMPLATE_FILE --parameters $PARAMETERS_FILE

echo "Deployment completed."