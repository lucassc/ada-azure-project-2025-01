resource "azurerm_kubernetes_cluster" "k8s" {
  name                    = "aks-cluster"
  location                = azurerm_resource_group.environment_rg.location
  resource_group_name     = azurerm_resource_group.environment_rg.name
  dns_prefix              = "k8s"
  private_cluster_enabled = false
  kubernetes_version      = "1.30.7"

  role_based_access_control_enabled = true

  default_node_pool {
    name            = "agentpool"
    os_disk_size_gb = 50
    type            = "VirtualMachineScaleSets"
    node_count      = var.agent_count
    vm_size         = var.vm_size
    vnet_subnet_id  = azurerm_subnet.cluster_resources.id
  }



  identity { type = "SystemAssigned" }
}
