Etapas necessarias 
- AKS
- Key vault 
- Database 
- managed identity
- kubernetes service account
- managed identity -> federacao com k8s service account
- configurar storage account no pod
- adicionar annotation na service account
- Add Permissao de Admin AKS
- configurar o label do pod para user workload identity
- Add Permissao no Key vault para adiconar a secret
- managed identity -> Permissao pra ler a secret
- configurar o firewall no banco de dados -> aks subnet 

```BASH
# kubectl run projeto --env SPD_KEY_VAULT_URI=https://kv-spd9-prod-brs-001.vault.azure.net/ \
#  --image schwendler/embarque-ti-spd-project --port 8080 -l azure.workload.identity/use=true \
#  --dry-run=client -o yaml

kubectl create deployment projeto --image schwendler/embarque-ti-spd-project --port 8080 --dry-run=client -o yaml > deployment.yaml

kubectl create sa projeto-sa --dry-run=client -oyaml > service-account.yaml

```

configurar:
 - labels
 - annotations
 - env's


```BASH
kubectl expose deployment projeto --dry-run=client -oyaml > service.yaml



az aks approuting enable --resource-group <ResourceGroupName> --name <ClusterName>
# az aks approuting enable --resource-group rg-spd9-prod-brs --name aks-spd9-prod-brs-001


kubectl create ingress projeto-ingress --class=webapprouting.kubernetes.azure.com \
  --rule="spd.com/*=projeto:8080" \
  --dry-run=client -oyaml > ingress.yaml
```

