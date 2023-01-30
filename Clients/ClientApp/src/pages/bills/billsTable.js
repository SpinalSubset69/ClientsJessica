import MUIDataTable from 'mui-datatables'
import React from 'react'



export default function BillsTable({ rows, columns }) {

    const options = {
        elevation: 5,
        selectableRowsHideCheckboxes: true,
        print: false,
        download: false
    }

    return (
        <>
            <MUIDataTable
                title="Registros de facturación"
                data={rows}
                columns={columns}
                options={options}
            />
        </>
    )
}
