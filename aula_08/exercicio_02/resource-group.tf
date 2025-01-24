resource "azurerm_resource_group" "environment_rg" {
  name     = "rg-spd-*-dev-brs"
  location = "Bra"
}