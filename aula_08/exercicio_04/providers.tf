# 1. Specify the version of the AzureRM Provider to use
terraform {
  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
      version = "4.16.0"
    }
  }
}

provider "azurerm" { 
  subscription_id = "190ce8be-6d75-4b0f-8a37-d2d821e9c662"
  features {}
}