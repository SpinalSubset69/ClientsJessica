import React, { useEffect, useState } from 'react'
import BillsTable from './billsTable'
import { toast, ToastContainer } from 'react-toastify';
import { Backdrop, CircularProgress, TextField } from '@mui/material';
import { Bills } from '../../api/bills';
import { Stack } from '@mui/system';
import { Button } from '@mui/material';

const columns = [
    { name: "name", label: "Nombre" },
    { name: "firstLastName", label: "Apellido Paterno" },
    { name: "secondLastName", label: "Apellido Materno" },
    { name: "rfc", label: "RFC" },
    { name: "curp", label: "CURP" },
    { name: "phone", label: "Teléfono" },
    { name: "email", label: "Email" },
    { name: "state", label: "Estado" },
    { name: "city", label: "Ciudad" },
    { name: "sector", label: "Colonia" },
    { name: "street", label: "Calle" },
    { name: "taxRegime", label: "Regimen Fiscal" },
    { name: "paymentDate", label: "Fecha de Pago" },
    { name: "amount", label: "Monto" },
    { name: "paymentMethod", label: "Método de Pago" },
]
export function BillsPage() {
    const [isLoading, setIsLoading] = useState(false);
    const [data, setData] = useState([]);
    const [isAuthorized, setIsAuthorized] = useState(false);
    const [password, setPassword] = useState("");

    const validateAccess = async (e) => {
        e.preventDefault();
        try {
            setIsLoading(true);
            const _bills = new Bills();
            const { data } = await _bills.ValidateAccesAsync(password);
            if (!data) toast.error("Acceso denegado");
            if (data) {
                const { data } = await _bills.GetAllBillsAsync();
                setData(data);
                setIsAuthorized(true);
                toast.success("Acceso");
            }
            setIsLoading(false);
        } catch (ex) {
            setIsLoading(false);
            toast.error("Error en el servidor");
            console.log(ex);
        }
    };

    return (
        <>
            <Backdrop
                sx={{ color: '#9ee5f8', zIndex: (theme) => theme.zIndex.drawer + 1 }}
                open={isLoading}>
                <CircularProgress color='inherit' />
            </Backdrop>
            <ToastContainer
                position='bottom-left'
                closeOnClick
                hideProgressBar
                autoClose={3000} />
            <>
                {
                    isAuthorized ? (
                        <BillsTable columns={columns} rows={data.map(x => ({ ...x, paymentDate: new Date(x.paymentDate).toLocaleDateString() }))} />
                    ) : (
                        <>
                            <h1>Ingrese contraseña para visualizar información</h1>
                            <form onSubmit={validateAccess}>
                                <Stack spacing={2}>
                                    <TextField
                                        fullWidth
                                        value={password}
                                        onChange={(e) => setPassword(e.target.value)}
                                        type="password"
                                        label="Contraseña" />
                                    <Button type='submit' variant='contained' fullWidth>Confirmar</Button>
                                </Stack>
                            </form>

                        </>
                    )
                }

            </>

        </>
    )
}
