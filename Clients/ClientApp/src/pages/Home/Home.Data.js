import * as Yup from 'yup';

export function initialValues() {
    return {
        RFC: '',
        CURP: '',
        Name: '',
        LastName: '',
        Email: '',
        PhoneNumber: ''
    }
}


export function validationSchema() {
    return Yup.object({
        RFC: Yup.string().required("RFC es obligatorio"),
        CURP: Yup.string().min(18, "CURP Inválido").max(18, "CURP Inválido").required("CURP es obligatorio"),
        Name: Yup.string().min(4, "Nombres Inválidos").required("Nombre Requerido"),
        LastName: Yup.string().min(4, "Apellidos Inválidos").required("Apellidos Requeridos"),
        Email: Yup.string().email("Email Inválido").required("Email Requerido"),
        PhoneNumber: Yup.string().min(10, "Número Inválido").max(10, "Número Inválido").required("Teléfono Requerido"),
    });
}