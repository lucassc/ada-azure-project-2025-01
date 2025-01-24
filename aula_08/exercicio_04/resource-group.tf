resource "azurerm_resource_group" "environment_rg" {
  name     = "rg-spd-aula7-dev-brs"
  location = var.resource_group_location
}