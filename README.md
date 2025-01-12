# Chatbot Builder API Service

## Development

### Setting Up Protos

1. Navigate to the infrastructure layer:
    ```bash
    cd ChatbotBuilderApi.Infrastructure
    ```

2. Clone the `chatbot-builder-protos` repository:
   ```bash
   git clone https://github.com/Chatbot-Builder-Project/chatbot-builder-protos.git
   ```
   Or update the repository if it already cloned:
   ```bash
   cd chatbot-builder-protos
   git pull
   cd ..
   ```

3. Copy the `chatbot-builder-protos/protos` directory to the `Protos` namespace:
   ```bash
   cp -r chatbot-builder-protos/protos Protos
   ```

4. Build the solution:
   ```bash
   dotnet build
   ```

## Notes

- Every entity uses Guid id, workflow components use int id because they are not database objects,
  they are just components of a workflow (identified within it) and using an int id is more convenient.
