import * as Yup from 'yup';

export function initialValues() {
    return {
        RFC: '',        
        Name: '',
        FirstLastName: '',
        SecondLastName: '',
        Email: '',
        Phone: '',
        CP: 0,
        Sector: '',
        Number: 0,
        Street: '',
        Reason: '',
        City: '',
        State: '',
        PaymentMethod: '',
        TaxRegime: '',
        CFDI: '',
        PaymentDate: new Date(),
        Amount: 0,
    }
}


export function validationSchema() {
    return Yup.object({
        RFC: Yup.string().min(12, "RFC Inválido").max(13, "RFC Inválido").required("RFC es obligatorio"),        
        Name: Yup.string().min(3, "Nombres Inválidos").required("Nombre Requerido"),
        FirstLastName: Yup.string().min(3, "Apellidos Inválidos").required("Apellido Paterno Requeridos"),
        SecondLastName: Yup.string().min(3, "Apellidos Inválidos").required("Apellido Materno Requeridos"),
        Email: Yup.string().email("Email Inválido").required("Email Requerido"),
        Phone: Yup.string().min(10, "Número Inválido").max(10, "Número Inválido").required("Teléfono Requerido"),
        CP: Yup.number().required("Código Postal Requerido"),
        Sector: Yup.string().min(3, "Colonia no válida").required("Colonia Requerida"),
        Number: Yup.number().required("Número Requerido"),
        Street: Yup.string().min(2, "Calle no válida").required("Calle Requerida"),
        Reason: Yup.string().min(1, "Persona no válida").required("Persona Requerida"),
        City: Yup.string().min(2, "Ciudad no válida").required("Ciudad Requerida"),
        State: Yup.string().min(4, "Estado no válido").required("Estado Requerido"),
        PaymentMethod: Yup.string().min(2, "Método de Pago no válido").required("Método de pago requerido"),
        TaxRegime: Yup.string().min(1, "Régimen Físcal no válido").required("Régimen Físcal Requerido"),
        CFDI: Yup.string().min(1, "CFDI no válido").required("Uso CFDI Requerido"),
        PaymentDate: Yup.date().required("Fecha de pago Requerida"),
        Amount: Yup.number().required("Monto Requerido"),
    });
} 