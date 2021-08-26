using AutoMapper;
using Romsoft.GESTIONCLINICA.Entidades;

namespace Romsoft.GESTIONCLINICA.DTO.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DtoToDomainMappingProfile"; }
        }
        protected override void Configure()
        {
            //SEG_USUARIO
            Mapper.CreateMap<TABLAS.SEG_USUARIO.SEG_USUARIODTO, Entidades.SEG_USUARIO.SEG_USUARIO>();
            Mapper.CreateMap<TABLAS.SEG_USUARIO.SEG_USUARIOLoginDTO, Entidades.SEG_USUARIO.SEG_USUARIO>();

            //SEG_ROL
            Mapper.CreateMap<TABLAS.SEG_ROL.SEG_ROLDTO, Entidades.SEG_USUARIO.SEG_USUARIO>();

            // TIPO ESTADO
            Mapper.CreateMap<TABLAS.TIPO_ESTADO.TIPO_ESTADODTO, Entidades.TIPO_ESTADO.TIPO_ESTADO>();

            // ADM_OCUPACION
            Mapper.CreateMap<TABLAS.ADM_OCUPACION.ADM_OCUPACIONDTO, Entidades.ADM_OCUPACION.ADM_OCUPACION>()
                .ForMember(p => p.id_usuarioCreacion, x => x.MapFrom(g => g.IdUsuarioActual))
                .ForMember(p => p.id_usuarioModifica, x => x.MapFrom(g => g.IdUsuarioActual));

            ////CVN_TARIFARIO_SEGUS
            Mapper.CreateMap<TABLAS.CVN_TARIFARIO_SEGUS.CVN_TARIFARIO_SEGUSDTO, Entidades.CVN_TARIFARIO_SEGUS.CVN_TARIFARIO_SEGUS>()
                .ForMember(p => p.id_usuarioCreacion, x => x.MapFrom(g => g.IdUsuarioActual))
                .ForMember(p => p.id_usuarioModifica, x => x.MapFrom(g => g.IdUsuarioActual));

            Mapper.CreateMap<TABLAS.CVN_TARIFARIO_SEGUS.CVN_TARIFARIO_SEGUSDTO, Entidades.CVN_TARIFARIO_SEGUS.CVN_TARIFARIO_LISTA>()
                .ForMember(p => p.id_tarifario_segus, x => x.MapFrom(g => g.id_tarifario_segus))
                .ForMember(p => p.c_codigo, x => x.MapFrom(g => g.c_codigo))
                .ForMember(p => p.c_codigo_susalud, x => x.MapFrom(g => g.c_codigo_susalud))
                .ForMember(p => p.t_descripcion_esp, x => x.MapFrom(g => g.t_descripcion_esp))
                .ForMember(p => p.t_descripcion_eng, x => x.MapFrom(g => g.t_descripcion_eng))
                .ForMember(p => p.t_observacion, x => x.MapFrom(g => g.t_observacion))
                .ForMember(p => p.t_clasificacion, x => x.MapFrom(g => g.t_clasificacion))
                .ForMember(p => p.estado, x => x.MapFrom(g => g.estado));

            // CVN_CLASIFICACION_SEGUS
            Mapper.CreateMap<TABLAS.CVN_CLASIFICACION_SEGUS.CVN_CLASIFICACION_SEGUSDTO, Entidades.CVN_CLASIFICACION_SEGUS.CVN_CLASIFICACION_SEGUS>();

            //CVN_CLASIFICACION_SUSALUD
            Mapper.CreateMap<TABLAS.CVN_CLASIFICACION_SUSALUD.CVN_CLASIFICACION_SUSALUDDTO, Entidades.CVN_CLASIFICACION_SUSALUD.CVN_CLASIFICACION_SUSALUD>();

            //CVN_CLASIFICACION_SUSALUD_OD
            Mapper.CreateMap<TABLAS.CVN_CLASIFICACION_SUSALUD_OD.CVN_CLASIFICACION_SUSALUD_ODDTO, Entidades.CVN_CLASIFICACION_SUSALUD_OD.CVN_CLASIFICACION_SUSALUD_OD>();
            //CVN_TIPO_PRECIO
            Mapper.CreateMap<TABLAS.CVN_TIPO_PRECIO.CVN_TIPO_PRECIODTO, Entidades.CVN_TIPO_PRECIO.CVN_TIPO_PRECIO>();
            //CON_CENTRO_COSTO
            Mapper.CreateMap<TABLAS.CON_CENTRO_COSTO.CON_CENTRO_COSTODTO, Entidades.CON_CENTRO_COSTO.CON_CENTRO_COSTO>();
            //CON_CUENTA_CONTABLE
            Mapper.CreateMap<TABLAS.CON_CUENTA_CONTABLE.CON_CUENTA_CONTABLEDTO, Entidades.CON_CUENTA_CONTABLE.CON_CUENTA_CONTABLE>();
            //CVN_TARIFARIO_SEGUS_PARTICIPANTE
            Mapper.CreateMap<TABLAS.CVN_TARIFARIO_SEGUS_PARTICIPANTE.CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO, Entidades.CVN_TARIFARIO_SEGUS_PARTICIPANTE.CVN_TARIFARIO_SEGUS_PARTICIPANTE>();
            //CVN_CATEGORIA_PAGO
            Mapper.CreateMap<TABLAS.CVN_CATEGORIA_PAGO.CVN_CATEGORIA_PAGODTO, Entidades.CVN_CATEGORIA_PAGO.CVN_CATEGORIA_PAGO>();
            ////CVN_CATEGORIA_PAGO_PRECIO
            Mapper.CreateMap<TABLAS.CVN_CATEGORIA_PAGO_PRECIO.CVN_CATEGORIA_PAGO_PRECIODTO, Entidades.CVN_CATEGORIA_PAGO_PRECIO.CVN_CATEGORIA_PAGO_PRECIO>();

            //// CON_CONTACTO
            Mapper.CreateMap<TABLAS.CON_CONTACTO.CON_CONTACTODTO, Entidades.CON_CONTACTO.CON_CONTACTO>();
            //CVN_PLAN_SEGURO
            Mapper.CreateMap<TABLAS.CVN_PLAN_SEGURO.CVN_PLAN_SEGURODTO, Entidades.CVN_PLAN_SEGURO.CVN_PLAN_SEGURO>();
            ////CVN_PRODUCTO_PLAN
            Mapper.CreateMap<TABLAS.CVN_PRODUCTO_PLAN.CVN_PRODUCTO_PLANDTO, Entidades.CVN_PRODUCTO_PLAN.CVN_PRODUCTO_PLAN>();
            //CVN_BENEFICIO
            Mapper.CreateMap<TABLAS.CVN_BENEFICIO.CVN_BENEFICIODTO, Entidades.CVN_BENEFICIO.CVN_BENEFICIO>();
            //CVN_MONEDA
            Mapper.CreateMap<TABLAS.CVN_MONEDA.CVN_MONEDADTO, Entidades.CVN_MONEDA.CVN_MONEDA>();
            //CON_TIPO_CONTACTO
            Mapper.CreateMap<TABLAS.CON_TIPO_CONTACTO.CON_TIPO_CONTACTODTO, Entidades.CON_TIPO_CONTACTO.CON_TIPO_CONTACTO>();
            //// ADM_PROFESIONAL
            Mapper.CreateMap<TABLAS.ADM_PROFESIONAL.ADM_PROFESIONALDTO, Entidades.ADM_PROFESIONAL.ADM_PROFESIONAL>();

            // ADM_GENERO
            Mapper.CreateMap<TABLAS.ADM_GENERO.ADM_GENERODTO, Entidades.ADM_GENERO.ADM_GENERO>();
            // ADM_DOCUMENTO_IDENTIDAD
            Mapper.CreateMap<TABLAS.ADM_DOCUMENTO_IDENTIDAD.ADM_DOCUMENTO_IDENTIDADDTO, Entidades.ADM_DOCUMENTO_IDENTIDAD.ADM_DOCUMENTO_IDENTIDAD>();
            // ADM_ESPECIALIDAD
            Mapper.CreateMap<TABLAS.ADM_ESPECIALIDAD.ADM_ESPECIALIDADDTO, Entidades.ADM_ESPECIALIDAD.ADM_ESPECIALIDAD>();
            Mapper.CreateMap<TABLAS.ADM_ESPECIALIDAD.ADM_ESPECIALIDADPROFESIONALDTO, Entidades.ADM_ESPECIALIDAD.ADM_ESPECIALIDADPROFESIONAL>();
            

            // ADM_TIPO_PROFESIONAL
            Mapper.CreateMap<TABLAS.ADM_TIPO_PROFESIONAL.ADM_TIPO_PROFESIONALDTO, Entidades.ADM_TIPO_PROFESIONAL.ADM_TIPO_PROFESIONAL>();
            // ADM_CONDICION_PROFESIONAL
            Mapper.CreateMap<TABLAS.ADM_CONDICION_PROFESIONAL.ADM_CONDICION_PROFESIONALDTO, Entidades.ADM_CONDICION_PROFESIONAL.ADM_CONDICION_PROFESIONAL>();
            // ADM_DOCUMENTO_AUTORIZACION
            Mapper.CreateMap<TABLAS.ADM_DOCUMENTO_AUTORIZACION.ADM_DOCUMENTO_AUTORIZACIONDTO, Entidades.ADM_DOCUMENTO_AUTORIZACION.ADM_DOCUMENTO_AUTORIZACION>();
            // ADM_PACIENTE
            Mapper.CreateMap<TABLAS.ADM_PACIENTE.ADM_PACIENTEDTO, Entidades.ADM_PACIENTE.ADM_PACIENTE>();
            Mapper.CreateMap<TABLAS.ADM_PACIENTE.ADM_PACIENTE_CONSULTADTO, Entidades.ADM_PACIENTE.ADM_PACIENTE_CONSULTA>();
            //ADM_ATENCION
            Mapper.CreateMap<TABLAS.ADM_ATENCION.ADM_ATENCIONDTO, Entidades.ADM_ATENCION.ADM_ATENCION>();
            Mapper.CreateMap<TABLAS.ADM_ATENCION.ADM_ATENCION_ResponseGetAllActivesDTO, Entidades.ADM_ATENCION.ADM_ATENCION_ResponseGetAllActives>();
            Mapper.CreateMap<TABLAS.ADM_ATENCION.ADM_ATENCION_RequestGetAllActiveDTO, Entidades.ADM_ATENCION.ADM_ATENCION_RequestGetAllActive>();
            //ADM_ESTADO_CIVIL
            Mapper.CreateMap<TABLAS.ADM_ESTADO_CIVIL.ADM_ESTADO_CIVILDTO, Entidades.ADM_ESTADO_CIVIL.ADM_ESTADO_CIVIL>();
            //ADM_GRUPO_SANGUINEO
            Mapper.CreateMap<TABLAS.ADM_GRUPO_SANGUINEO.ADM_GRUPO_SANGUINEODTO, Entidades.ADM_GRUPO_SANGUINEO.ADM_GRUPO_SANGUINEO>();
            //ADM_UBIGEO
            Mapper.CreateMap<TABLAS.ADM_UBIGEO.ADM_UBIGEODTO, Entidades.ADM_UBIGEO.ADM_UBIGEO>();
            //ADM_TIPO_PACIENTE
            Mapper.CreateMap<TABLAS.ADM_TIPO_PACIENTE.ADM_TIPO_PACIENTEDTO, Entidades.ADM_TIPO_PACIENTE.ADM_TIPO_PACIENTE>();
            //ADM_TIPO_ATENCION
            Mapper.CreateMap<TABLAS.ADM_TIPO_ATENCION.ADM_TIPO_ATENCIONDTO, Entidades.ADM_TIPO_ATENCION.ADM_TIPO_ATENCION>();
            //ADM_CONSULTORIO
            Mapper.CreateMap<TABLAS.ADM_CONSULTORIO.ADM_CONSULTORIODTO, Entidades.ADM_CONSULTORIO.ADM_CONSULTORIO>();
            //ADM_DOCUMENTO_PRESTACION
            Mapper.CreateMap<TABLAS.ADM_DOCUMENTO_PRESTACION.ADM_DOCUMENTO_PRESTACIONDTO, Entidades.ADM_DOCUMENTO_PRESTACION.ADM_DOCUMENTO_PRESTACION>();
            //ADM_TIPO_FILIACION
            Mapper.CreateMap<TABLAS.ADM_TIPO_AFILIACION.ADM_TIPO_AFILIACIONDTO, Entidades.ADM_TIPO_AFILIACION.ADM_TIPO_AFILIACION>();
            //ADM_CIE10
            Mapper.CreateMap<TABLAS.ADM_CIE10.ADM_CIE10DTO, Entidades.ADM_CIE10.ADM_CIE10>();
            //ADM_TIPO_CIE10
            Mapper.CreateMap<TABLAS.ADM_TIPO_CIE10.ADM_TIPO_CIE10DTO, Entidades.ADM_TIPO_CIE10.ADM_TIPO_CIE10>();
            //ADM_PROFESIONAL
            Mapper.CreateMap<TABLAS.ADM_PROFESIONAL.ADM_PROFESIONALDTO, Entidades.ADM_PROFESIONAL.ADM_PROFESIONAL>();
            //ADM_TIPO_HOSPITALIZACION
            Mapper.CreateMap<TABLAS.ADM_TIPO_HOSPITALIZACION.ADM_TIPO_HOSPITALIZACIONDTO, Entidades.ADM_TIPO_HOSPITALIZACION.ADM_TIPO_HOSPITALIZACION>();
            //ADM_HABITACION
            Mapper.CreateMap<TABLAS.ADM_HABITACION.ADM_HABITACIONDTO, Entidades.ADM_HABITACION.ADM_HABITACION>();
            //ADM_TIPO_EGRESO
            Mapper.CreateMap<TABLAS.ADM_TIPO_EGRESO.ADM_TIPO_EGRESODTO, Entidades.ADM_TIPO_EGRESO.ADM_TIPO_EGRESO>();
            //ADM_TIPO_AAFILIACION
            Mapper.CreateMap<TABLAS.ADM_TIPO_AAFILIACION.ADM_TIPO_AAFILIACIONDTO, Entidades.ADM_TIPO_AAFILIACION.ADM_TIPO_AAFILIACION>();
            //ADM_DOCUMENTO_AUTORIZACION_REQ
            Mapper.CreateMap<TABLAS.ADM_DOCUMENTO_AUTORIZACION.ADM_DOCUMENTO_AUTORIZACION_REQDTO, Entidades.ADM_DOCUMENTO_AUTORIZACION.ADM_DOCUMENTO_AUTORIZACION_REQ>();
            Mapper.CreateMap<TABLAS.ADM_DOCUMENTO_AUTORIZACION.ADM_DOCUMENTO_AUTORIZACION_RESDTO, Entidades.ADM_DOCUMENTO_AUTORIZACION.ADM_DOCUMENTO_AUTORIZACION_RES>();

            Mapper.CreateMap<TABLAS.FAC_DOCUMENTO_PAGO.FAC_DOCUMENTO_PAGODTO, Entidades.FAC_DOCUMENTO_PAGO.FAC_DOCUMENTO_PAGO>();

            Mapper.CreateMap<TABLAS.ADM_ATENCION.ADM_ATENCION_ResponseGetAllActivesDTO, Entidades.ADM_ATENCION.ADM_ATENCION_ResponseGetAllActives>();
            Mapper.CreateMap<TABLAS.FAC_DOCUMENTO_PAGO.FAC_COMPROBANTEReqDTO, Entidades.FAC_DOCUMENTO_PAGO.FAC_COMPROBANTEReq>();
            Mapper.CreateMap<TABLAS.FAC_DOCUMENTO_PAGO.FAC_COMPROBANTE_DetalleDTO, Entidades.FAC_DOCUMENTO_PAGO.FAC_COMPROBANTE_Detalle>();

        }

    }
 
}
