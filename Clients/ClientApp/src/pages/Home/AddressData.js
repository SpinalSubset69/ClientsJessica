import { Autocomplete, Stack, TextField } from '@mui/material';
import React from 'react'
import { STATES } from '../../constants';

export default function AddressData({ formik }) {
    return (
        <>
            <Stack spacing={1} direction="row">
                <TextField
                    name='Street'
                    InputLabelProps={{ shrink: formik.values.Street }}
                    value={formik.values.Street}
                    onChange={formik.handleChange}
                    error={formik.errors.Street}
                    helperText={formik.errors.Street}
                    variant="outlined"
                    label="Calle"
                />
                <TextField
                    name='Number'
                    InputLabelProps={{ shrink: formik.values.Street }}
                    inputProps={{
                        inputMode: 'numeric', pattern: '[0-9]*', onInput: (e) => {
                            e.target.value = e.target.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');
                        },
                        maxLength: "5",                        
                    }}
                    value={formik.values.Number}
                    onChange={formik.handleChange}
                    error={formik.errors.Number}
                    helperText={formik.errors.Number}
                    variant="outlined"
                    label="Número "
                />

                <TextField
                    name='Sector'
                    InputLabelProps={{ shrink: formik.values.Sector }}
                    value={formik.values.Sector}
                    onChange={formik.handleChange}
                    error={formik.errors.Sector}
                    helperText={formik.errors.Sector}
                    variant="outlined"
                    label="Colonia"
                />
            </Stack>

            <Stack spacing={1} direction="row">

                <Autocomplete
                    disablePortal
                    sx={{ width: 300 }}
                    options={STATES}
                    name='State'
                    value={formik.values.State}
                    onChange={(e, value) => formik.setFieldValue("State", value.label)}
                    renderInput={(params) =>
                        <TextField {...params}
                            error={formik.errors.State}
                            helperText={formik.errors.State}
                            label="Seleccione un Estado" />
                    }
                />


                <TextField
                    name='City'
                    InputLabelProps={{ shrink: formik.values.City }}
                    value={formik.values.City}
                    onChange={formik.handleChange}
                    error={formik.errors.City}
                    helperText={formik.errors.City}
                    variant="outlined"
                    label="Ciudad"
                />

                <TextField
                    name='CP'
                    InputLabelProps={{ shrink: formik.values.CP }}
                    value={formik.values.CP}
                    onChange={formik.handleChange}
                    error={formik.errors.CP}
                    helperText={formik.errors.CP}
                    variant="outlined"
                    label="Código Postal"
                />
            </Stack>

        </>
    )
}
