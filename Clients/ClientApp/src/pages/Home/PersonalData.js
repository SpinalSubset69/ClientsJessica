import { FormControl, InputLabel, MenuItem, Select, Stack, TextField } from '@mui/material';
import { DesktopDatePicker, LocalizationProvider } from '@mui/x-date-pickers';
import React from 'react'
import { Bills } from '../../api/bills';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { PAYMENT_METHODS } from '../../constants';

export default function PersonalData({ formik }) {

    const getPersonalDataByRFC = async () => {
        const rfc = formik.values.RFC;
        try {
            if (!rfc || rfc.length < 10) return;
            const _bills = new Bills();
            var { data } = await _bills.GetPersonalDataByRFCAsync(formik.values.RFC);
            if (!data) return;
            formik.setFieldValue("City", data.city);
            formik.setFieldValue("CP", data.cp);
            formik.setFieldValue("CURP", data.curp);
            formik.setFieldValue("Email", data.email);
            formik.setFieldValue("Name", data.name);
            formik.setFieldValue("FirstLastName", data.firstLastName);
            formik.setFieldValue("SecondLastName", data.secondLastName);
            formik.setFieldValue("Number", data.number);
            formik.setFieldValue("Phone", data.phone);
            formik.setFieldValue("Sector", data.sector);
            formik.setFieldValue("State", data.state);
            formik.setFieldValue("Street", data.street);
            formik.setFieldValue("TaxRegime", data.taxRegime);
        } catch (ex) {
            console.log(ex);
        }
    }

    return (
        <>
            <Stack spacing={1} direction="row">
                <TextField
                    InputLabelProps={{ shrink: formik.values.Name }}
                    inputProps={{ style: { textTransform: 'capitalize' } }}
                    name='Name'
                    value={formik.values.Name}
                    onChange={formik.handleChange}
                    error={formik.errors.Name}
                    helperText={formik.errors.Name}
                    variant="outlined"
                    label="Nombre o Razón Social"
                />

                <TextField
                    InputLabelProps={{ shrink: formik.values.FirstLastName }}
                    inputProps={{ style: { textTransform: 'capitalize' } }}
                    name='FirstLastName'
                    value={formik.values.FirstLastName}
                    onChange={formik.handleChange}
                    error={formik.errors.FirstLastName}
                    helperText={formik.errors.FirstLastName}
                    variant="outlined"
                    label="Apellido Paterno"
                />

                <TextField
                    InputLabelProps={{ shrink: formik.values.SecondLastName }}
                    inputProps={{ style: { textTransform: 'capitalize' } }}
                    name='SecondLastName'
                    value={formik.values.SecondLastName}
                    onChange={formik.handleChange}
                    error={formik.errors.SecondLastName}
                    helperText={formik.errors.SecondLastName}
                    variant="outlined"
                    label="Apellido Materno"
                />
            </Stack>

            <Stack spacing={1} direction="row">
                <TextField
                    InputLabelProps={{ shrink: formik.values.Email }}
                    name='Email'
                    value={formik.values.Email}
                    onChange={formik.handleChange}
                    error={formik.errors.Email}
                    helperText={formik.errors.Email}
                    variant="outlined"
                    label="Correo Electrónico"
                />

                <TextField
                    InputLabelProps={{ shrink: formik.values.Phone }}
                    name='Phone'
                    inputProps={{
                        inputMode: 'numeric', pattern: '[0-9]*', onInput: (e) => {
                            e.target.value = e.target.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');
                        },
                        maxLength: "10"
                    }}
                    value={formik.values.Phone}
                    onChange={formik.handleChange}
                    error={formik.errors.Phone}
                    helperText={formik.errors.Phone}
                    variant="outlined"
                    label="Número Telefónico"
                />
            </Stack>

            <Stack spacing={1} direction="row">
                <TextField
                    inputProps={{ style: { textTransform: 'uppercase' }, onBlur: getPersonalDataByRFC }}
                    name='RFC'
                    value={formik.values.RFC}
                    onChange={formik.handleChange}
                    error={formik.errors.RFC}
                    helperText={formik.errors.RFC}
                    variant="outlined"
                    label="RFC"
                />

                <TextField
                    InputLabelProps={{ shrink: formik.values.CFDI }}
                    inputProps={{ style: { textTransform: 'uppercase' }, maxLength: "18" }}
                    name='CFDI'
                    value={formik.values.CFDI}
                    onChange={formik.handleChange}
                    error={formik.errors.CFDI}
                    helperText={formik.errors.CFDI}
                    variant="outlined"
                    label="Uso CFDI"
                />

                <TextField
                    InputLabelProps={{ shrink: formik.values.TaxRegime }}
                    inputProps={{ style: { textTransform: 'uppercase' }, maxLength: "18" }}
                    name='TaxRegime'
                    value={formik.values.TaxRegime}
                    onChange={formik.handleChange}
                    error={formik.errors.TaxRegime}
                    helperText={formik.errors.TaxRegime}
                    variant="outlined"
                    label="Régimen Físcal"
                />
            </Stack>

            <Stack spacing={1} direction="row">
                <Stack >
                    <FormControl>
                        <InputLabel>Método de Pago</InputLabel>
                        <Select
                            name='PaymentMethod'
                            value={formik.values.PaymentMethod}
                            onChange={formik.handleChange}
                            error={formik.errors.PaymentMethod}
                            helperText={formik.errors.PaymentMethod}
                            label="Método de Pago"
                            sx={{ width: 300 }}
                        >
                            {
                                PAYMENT_METHODS.map(paymentMethod => (
                                    <MenuItem key={paymentMethod.id} value={paymentMethod.key}>{paymentMethod.value}</MenuItem>
                                ))
                            }
                        </Select>
                        {formik.errors.PaymentMethod ? <span style={{ color: 'red', fontSize: 14 }}>{formik.errors.PaymentMethod}</span> : null}
                    </FormControl>

                </Stack>

                <Stack>
                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                        <DesktopDatePicker
                            label="Fecha de Pago"
                            inputFormat='YYYY/MM/DD'
                            value={formik.values.PaymentDate}
                            onChange={(value) => {
                                formik.setValues({
                                    ...formik.values,
                                    PaymentDate: value
                                });
                            }}
                            renderInput={(params) => <TextField {...params} />}
                        />
                    </LocalizationProvider>
                    {formik.errors.PaymentDate ? <span style={{ color: 'red', fontSize: 14 }}>{formik.errors.PaymentDate}</span> : null}
                </Stack>

                <TextField
                    inputProps={{
                        inputMode: 'numeric', onInput: (e) => {
                            e.target.value = e.target.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g, '$1');
                        }
                    }}
                    name='Amount'
                    value={formik.values.Amount}
                    onChange={formik.handleChange}
                    error={formik.errors.Amount}
                    helperText={formik.errors.Amount}
                    variant="outlined"
                    label="Monto"
                />
            </Stack>
        </>
    )
}
