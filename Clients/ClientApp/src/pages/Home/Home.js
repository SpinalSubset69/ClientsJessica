import React from 'react';
import { Container } from 'reactstrap';
import { useFormik, FormikProvider } from 'formik';
import { initialValues, validationSchema } from './Home.Data';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import { Bills } from '../../api/bills';


export function Home() {
  const _bills = new Bills();
  const formik = useFormik({
    initialValues: initialValues,
    validateOnChange: false,
    validationSchema: validationSchema,
    onSubmit: async (formValues) => {
      try {
        console.log(formValues);
        const data = await _bills.GetBillsAsync();
        console.log(data);

      } catch (error) {
        console.error(error);
      }
    }
  });

  return (
    <Container>
      <h1>Rellenar Formulario</h1>
      <FormikProvider value={formik}>
        <form onSubmit={formik.handleSubmit}>

          <Stack spacing={2}>
            <Stack spacing={1} direction="row">
              <TextField
                inputProps={{ style: { textTransform: 'uppercase' } }}
                name='RFC'
                value={formik.values.RFC}
                onChange={formik.handleChange}
                error={formik.errors.RFC}
                helperText={formik.errors.RFC}
                variant="outlined"
                label="RFC"
              />

              <TextField
                inputProps={{ style: { textTransform: 'uppercase' }, maxlength: "18" }}
                name='CURP'
                value={formik.values.CURP}
                onChange={formik.handleChange}
                error={formik.errors.CURP}
                helperText={formik.errors.CURP}
                variant="outlined"
                label="CURP"
              />

              <TextField
                inputProps={{ style: { textTransform: 'capitalize' } }}
                name='Name'
                value={formik.values.Name}
                onChange={formik.handleChange}
                error={formik.errors.Name}
                helperText={formik.errors.Name}
                variant="outlined"
                label="Nombres"
              />

              <TextField
                inputProps={{ style: { textTransform: 'capitalize' } }}
                name='LastName'
                value={formik.values.LastName}
                onChange={formik.handleChange}
                error={formik.errors.LastName}
                helperText={formik.errors.LastName}
                variant="outlined"
                label="Apellidos"
              />
            </Stack>

            <Stack spacing={1} direction="row">
              <TextField
                name='Email'
                value={formik.values.Email}
                onChange={formik.handleChange}
                error={formik.errors.Email}
                helperText={formik.errors.Email}
                variant="outlined"
                label="Correo Electrónico"
              />

              <TextField
                name='PhoneNumber'
                inputProps={{
                  inputMode: 'numeric', pattern: '[0-9]*', onInput: (e) => {
                    e.target.value = e.target.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');
                  },
                  maxlength: "10"
                }}
                value={formik.values.PhoneNumber}
                onChange={formik.handleChange}
                error={formik.errors.PhoneNumber}
                helperText={formik.errors.PhoneNumber}
                variant="outlined"
                label="Número Telefónico"
              />
            </Stack>

            <Button variant='contained' type='submit'>Emitir</Button>
          </Stack>
        </form>
      </FormikProvider>

    </Container>
  )
}
