# PrepayPower technical assessment

This solution is made by Gergo Hajzer in 26/03/2023.

To run the application you need to run the following command:

`dotnet run --project ./src/ConsoleApp/ "${path_to_vegetables_import_csv_file}" "${path_to_purchase_import_csv_file}" "${output_folder}"`

${path_to_vegetables_import_csv_file} is the file path to your csv file that contains vegetables and their prices in the following format:

````
PRODUCT,PRICE
Tomato,0.75
Aubergine,0.9
Carrot,1
````

${path_to_purchase_import_csv_file} is the file path to your csv file that represents a purchase and contains vegetables and their quantity in the following format:

````
PRODUCT,QUANTITY
Tomato,3
Aubergine,25
Carrot,12
````
${output_folder} is the path for your output folder.
