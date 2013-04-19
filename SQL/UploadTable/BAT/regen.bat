@echo off
codegen -t DatabaseTableTest                    -n SqlUploadDemo    -v
codegen -t DatabaseTableMapped -s CUSTOMER      -n SqlUploadDemo -r -v
codegen -t DatabaseTableMapped -s ORDER_HEADER  -n SqlUploadDemo -r -v
codegen -t DatabaseTableMapped -s ORDER_LINE    -n SqlUploadDemo -r -v
codegen -t DatabaseTableMapped -s PRODUCT       -n SqlUploadDemo -r -v
codegen -t DatabaseTableMapped -s PRODUCT_GROUP -n SqlUploadDemo -r -v

