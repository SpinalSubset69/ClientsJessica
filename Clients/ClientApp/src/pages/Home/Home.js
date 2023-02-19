import React, { useState } from 'react';
import { Container } from 'reactstrap';
import { useFormik, FormikProvider } from 'formik';
import { initialValues, validationSchema } from './Home.Data';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import { Bills } from '../../api/bills';
import { Backdrop } from '@mui/material';
import CircularProgress from '@mui/material/CircularProgress';
import { toast, ToastContainer } from 'react-toastify';
import PersonalData from './PersonalData';
import AddressData from './AddressData';

export function Home() {
  const [isLoading, setIsLoading] = useState(false);
  const formik = useFormik({
    initialValues: initialValues,
    validateOnChange: false,
    validateOnBlur: true,
    validationSchema: validationSchema,
    onSubmit: async (formValues) => {
      try {
        setIsLoading(true);
        const _bills = new Bills();
        await _bills.CreateBillAsync(formValues);
        setIsLoading(false);
        toast.success("Información Emitida")
        formik.resetForm({ values: initialValues() });        
      } catch (err) {
        console.log(err);
        setIsLoading(false);
        toast.error("Error en el servidor");
      }
    },
  });

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

      <Container>
        <h1 className='animate__animated animate__fadeIn'>Rellenar formulario para solicitud de recibo honorarios</h1>
        <FormikProvider value={formik}>
          <form className='animate__animated animate__fadeInUp' onSubmit={formik.handleSubmit}>
            <Stack spacing={2}>

              <Stack spacing={1} direction="row" className='reason-container'>
                <p className='dr__title'>Doctor(a) quién prestó el servicio</p>
                <TextField
                  inputProps={{ style: { textTransform: 'capitalize' } }}
                  name='Reason'
                  value={formik.values.Reason}
                  onChange={formik.handleChange}
                  error={formik.errors.Reason}
                  helperText={formik.errors.Reason}
                  variant="outlined"
                  label="Persona"
                />
              </Stack>

              <h3>Datos Personales</h3>
              <PersonalData formik={formik} />

              <h3>Dirección</h3>
              <AddressData formik={formik} />

              <Button variant='contained' type='submit'>Enviar solicitud de CFDI</Button>
            </Stack>
          </form>
        </FormikProvider>

      </Container>
    </>
  )
}
