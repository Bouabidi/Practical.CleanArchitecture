- Login Azure
```
az login
```

- Create Resource Group
```
az group create --name "ClassifiedAds_DEV" \
                --location "southeastasia" \
                --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD" "ResourceType=Mixed"
```

- Create Storage Account
```
az storage account create --resource-group "ClassifiedAds_DEV" \
                          --name "classifiedadsdev" \
                          --location "southeastasia" \
                          --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD"
```

- Create SQL Server (classifiedads/SqlAdmin123!@#)
```
az sql server create --resource-group "ClassifiedAds_DEV" \
                     --name "classifiedadsdev" \
                     --location "southeastasia" \
                     --admin-user "classifiedads" \
                     --admin-password "SqlAdmin123"'!''@''#'
```

- Configure Firewall
```
az sql server firewall-rule create --resource-group "ClassifiedAds_DEV" \
                                   --server "classifiedadsdev" \
                                   -n "Allow Azure services and resources to access this server" \
                                   --start-ip-address 0.0.0.0 \
                                   --end-ip-address 0.0.0.0
                                    
 az sql server firewall-rule create --resource-group "ClassifiedAds_DEV" \
                                    --server "classifiedadsdev" \
                                    -n "Your IP Address" \
                                    --start-ip-address "Your IP Address" \
                                    --end-ip-address "Your IP Address"                                   
```

- Create SQL Database
```
az sql db create --resource-group "ClassifiedAds_DEV" \
                 --name "classifiedadsdevdb" \
                 --server  "classifiedadsdev" \
                 --service-objective Basic \
                 --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD"
```

- Create Key Vault
```
az keyvault create --resource-group "ClassifiedAds_DEV" \
                   --name "classifiedadsdev" \
                   --location "southeastasia" \
                   --sku Standard \
                   --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD"
```

- Creeate Service Bus Name Space
```
az servicebus namespace create --resource-group "ClassifiedAds_DEV" \
                               --name classifiedadsdev \
                               --location "southeastasia" \
                               --sku Standard \
                               --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD"
```

- Create Service Bus Queues
```
az servicebus queue create --resource-group "ClassifiedAds_DEV" \
                           --namespace-name "classifiedadsdev" \
                           --name classifiedadds_fileuploaded \
                           --max-size 1024
                           
az servicebus queue create --resource-group "ClassifiedAds_DEV" \
                           --namespace-name "classifiedadsdev" \
                           --name classifiedadds_filedeleted \
                           --max-size 1024
```

- Create Service Bus Topics
```
az servicebus topic create --resource-group "ClassifiedAds_DEV" \
                           --namespace-name "classifiedadsdev" \
                           --name topic_fileuploaded \
                           --max-size 1024
                            
 az servicebus topic create --resource-group "ClassifiedAds_DEV" \
                            --namespace-name "classifiedadsdev" \
                            --name topic_filedeleted \
                            --max-size 1024
```

- Create Service Bus Subscriptions
```
az servicebus topic subscription create --resource-group "ClassifiedAds_DEV" \
                                        --namespace-name "classifiedadsdev" \
                                        --topic-name topic_fileuploaded \
                                        --name sub_fileuploaded
                            
az servicebus topic subscription create --resource-group "ClassifiedAds_DEV" \
                                        --namespace-name "classifiedadsdev" \
                                        --topic-name topic_filedeleted \
                                        --name sub_filedeleted
```

- Create Event Grid Domain
```
az eventgrid domain create --resource-group "ClassifiedAds_DEV" \
                           --name classifiedadsdev \
                           --location "southeastasia" \
                           --sku Basic \
                           --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD"
```

- Create Event Hub Name Space
```
az eventhubs namespace create --resource-group "ClassifiedAds_DEV" \
                              --name classifiedadshubsdev \
                              --location "southeastasia" \
                              --sku Basic \
                              --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD"
```

- Create Event Hubs
```
az eventhubs eventhub create --resource-group "ClassifiedAds_DEV" \
                             --namespace-name "classifiedadshubsdev" \
                             --name classifiedadds_fileuploaded \
                             --message-retention 1 \
                             --partition-count 2
                             
az eventhubs eventhub create --resource-group "ClassifiedAds_DEV" \
                             --namespace-name "classifiedadshubsdev" \
                             --name classifiedadds_filedeleted \
                             --message-retention 1 \
                             --partition-count 2
```

- Create Application Insights
```
az extension add -n application-insights

az monitor app-insights component create --resource-group "ClassifiedAds_DEV" \
                                         --app ClassifiedAds.WebAPI \
                                         --location "southeastasia" \
                                         --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD"
```

- Create Azure Container Registry
```
az acr create --resource-group "ClassifiedAds_DEV" \
              --name classifiedads \
              --location "southeastasia" \
              --sku Basic \
              --admin-enabled true \
              --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD"
```

- Create App Service Plan
```
az appservice plan create --resource-group "ClassifiedAds_DEV" \
                          --name ClassifiedAds-Hosts \
                          --location "southeastasia" \
                          --sku B1 \
                          --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD"
```

- Create App Services:
```
az webapp create --resource-group "ClassifiedAds_DEV" \
                 --plan ClassifiedAds-Hosts \
                 --name identityserver-classifiedads \
                 --runtime "DOTNETCORE|3.1" \
                 --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD"

az webapp create --resource-group "ClassifiedAds_DEV" \
                 --plan ClassifiedAds-Hosts \
                 --name webapi-classifiedads \
                 --runtime "DOTNETCORE|3.1" \
                 --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD"
                 
az webapp create --resource-group "ClassifiedAds_DEV" \
                 --plan ClassifiedAds-Hosts \
                 --name webmvc-classifiedads \
                 --runtime "DOTNETCORE|3.1" \
                 --tags "Environment=Development" "Project=ClassifiedAds" "Department=SD"                 
```

- Clean Up
```
az group delete --name "ClassifiedAds_DEV" --yes
```
