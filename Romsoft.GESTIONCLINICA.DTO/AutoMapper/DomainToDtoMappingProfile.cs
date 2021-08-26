using AutoMapper;
using Romsoft.GESTIONCLINICA.Entidades;

namespace Romsoft.GESTIONCLINICA.DTO.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToDtoMappingProfile"; }
        }

        protected override void Configure()
        {
            //SEG_USAURIO
            Mapper.CreateMap<Entidades.SEG_USUARIO.SEG_USUARIO, TABLAS.SEG_USUARIO.SEG_USUARIODTO>();
            Mapper.CreateMap<Entidades.SEG_USUARIO.SEG_USUARIO, TABLAS.SEG_USUARIO.SEG_USUARIOLoginDTO>();

            //SEG_ROL
            Mapper.CreateMap<Entidades.SEG_ROL.SEG_ROL, TABLAS.SEG_ROL.SEG_ROLDTO>();

            // TIPO ESTADO
            Mapper.CreateMap<Entidades.TIPO_ESTADO.TIPO_ESTADO, TABLAS.TIPO_ESTADO.TIPO_ESTADODTO>();

            //ADM_OCUPACION
            Mapper.CreateMap<Entidades.ADM_OCUPACION.ADM_OCUPACION, TABLAS.ADM_OCUPACION.ADM_OCUPACIONDTO>()
                .ForMember(p => p.IdUsuarioActual, x => x.MapFrom(g => g.id_usuarioCreacion))
                .ForMember(p => p.IdUsuarioActual, x => x.MapFrom(g => g.id_usuarioModifica));

            //CVN_TARIFARIO_SEGUS
            Mapper.CreateMap<Entidades.CVN_TARIFARIO_SEGUS.CVN_TARIFARIO_SEGUS, TABLAS.CVN_TARIFARIO_SEGUS.CVN_TARIFARIO_SEGUSDTO>()
                .ForMember(p => p.IdUsuarioActual, x => x.MapFrom(g => g.id_usuarioCreacion))
                .ForMember(p => p.IdUsuarioActual, x => x.MapFrom(g => g.id_usuarioModifica));

            Mapper.CreateMap<Entidades.CVN_TARIFARIO_SEGUS.CVN_TARIFARIO_SEGUS, TABLAS.CVN_TARIFARIO_SEGUS.CVN_TARIFARIO_LISTADTO>()
                .ForMember(p => p.id_tarifario_segus, x => x.MapFrom(g => g.id_tarifario_segus))
                .ForMember(p => p.c_codigo, x => x.MapFrom(g => g.c_codigo))
                .ForMember(p => p.c_codigo_susalud, x => x.MapFrom(g => g.c_codigo_susalud))
                .ForMember(p => p.t_descripcion_esp, x => x.MapFrom(g => g.t_descripcion_esp))
                .ForMember(p => p.t_descripcion_eng, x => x.MapFrom(g => g.t_descripcion_eng))
                .ForMember(p => p.t_observacion, x => x.MapFrom(g => g.t_observacion))
                .ForMember(p => p.t_clasificacion, x => x.MapFrom(g => g.t_clasificacion))
                .ForMember(p => p.estado, x => x.MapFrom(g => g.estado));

            // CVN_CLASIFICACION_SEGUS
            Mapper.CreateMap<Entidades.CVN_CLASIFICACION_SEGUS.CVN_CLASIFICACION_SEGUS, TABLAS.CVN_CLASIFICACION_SEGUS.CVN_CLASIFICACION_SEGUSDTO>();

            //CVN_CLASIFICACION_SUSALUD
            Mapper.CreateMap<Entidades.CVN_CLASIFICACION_SUSALUD.CVN_CLASIFICACION_SUSALUD, TABLAS.CVN_CLASIFICACION_SUSALUD.CVN_CLASIFICACION_SUSALUDDTO>();

            // CVN_CLASIFICACION_SUSALUD_OD
            Mapper.CreateMap<Entidades.CVN_CLASIFICACION_SUSALUD_OD.CVN_CLASIFICACION_SUSALUD_OD, TABLAS.CVN_CLASIFICACION_SUSALUD_OD.CVN_CLASIFICACION_SUSALUD_ODDTO>();
            //CVN_TIPO_PRECIO
            Mapper.CreateMap<Entidades.CVN_TIPO_PRECIO.CVN_TIPO_PRECIO, TABLAS.CVN_TIPO_PRECIO.CVN_TIPO_PRECIODTO>();
            //CON_CENTRO_COSTO
            Mapper.CreateMap<Entidades.CON_CENTRO_COSTO.CON_CENTRO_COSTO, TABLAS.CON_CENTRO_COSTO.CON_CENTRO_COSTODTO>();
            //CON_CUENTA_CONTABLE
            Mapper.CreateMap<Entidades.CON_CUENTA_CONTABLE.CON_CUENTA_CONTABLE, TABLAS.CON_CUENTA_CONTABLE.CON_CUENTA_CONTABLEDTO>();
            //CVN_TARIFARIO_SEGUS_PARTICIPANTE
            Mapper.CreateMap<Entidades.CVN_TARIFARIO_SEGUS_PARTICIPANTE.CVN_TARIFARIO_SEGUS_PARTICIPANTE, TABLAS.CVN_TARIFARIO_SEGUS_PARTICIPANTE.CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO>();
            //CVN_CATEGORIA_PAGO
            Mapper.CreateMap<Entidades.CVN_CATEGORIA_PAGO.CVN_CATEGORIA_PAGO, TABLAS.CVN_CATEGORIA_PAGO.CVN_CATEGORIA_PAGODTO>();
            //CVN_CATEGORIA_PAGO_PRECIO
            Mapper.CreateMap<Entidades.CVN_CATEGORIA_PAGO_PRECIO.CVN_CATEGORIA_PAGO_PRECIO, TABLAS.CVN_CATEGORIA_PAGO_PRECIO.CVN_CATEGORIA_PAGO_PRECIODTO>();
            // CON_CONTACTO
            Mapper.CreateMap<Entidades.CON_CONTACTO.CON_CONTACTO, TABLAS.CON_CONTACTO.CON_CONTACTODTO>();
            //CVN_PLAN_SEGURO
            Mapper.CreateMap<Entidades.CVN_PLAN_SEGURO.CVN_PLAN_SEGURO, TABLAS.CVN_PLAN_SEGURO.CVN_PLAN_SEGURODTO>();
            //CVN_PRODUCTO_PLAN
            Mapper.CreateMap<Entidades.CVN_PRODUCTO_PLAN.CVN_PRODUCTO_PLAN, TABLAS.CVN_PRODUCTO_PLAN.CVN_PRODUCTO_PLANDTO>();
            //CVN_BENEFICIO
            Mapper.CreateMap<Entidades.CVN_BENEFICIO.CVN_BENEFICIO, TABLAS.CVN_BENEFICIO.CVN_BENEFICIODTO>();
            //CVN_MONEDA
            Mapper.CreateMap<Entidades.CVN_MONEDA.CVN_MONEDA, TABLAS.CVN_MONEDA.CVN_MONEDADTO>();
            //CON_TIPO_CONTACTO
            Mapper.CreateMap<Entidades.CON_TIPO_CONTACTO.CON_TIPO_CONTACTO, TABLAS.CON_TIPO_CONTACTO.CON_TIPO_CONTACTODTO>();
            // ADM_PROFESIONAL
            Mapper.CreateMap<Entidades.ADM_PROFESIONAL.ADM_PROFESIONAL, TABLAS.ADM_PROFESIONAL.ADM_PROFESIONALDTO>();
            // ADM_GENERO
            Mapper.CreateMap<Entidades.ADM_GENERO.ADM_GENERO, TABLAS.ADM_GENERO.ADM_GENERODTO>();
            // ADM_DOCUMENTO_IDENTIDAD
            Mapper.CreateMap<Entidades.ADM_DOCUMENTO_IDENTIDAD.ADM_DOCUMENTO_IDENTIDAD, TABLAS.ADM_DOCUMENTO_IDENTIDAD.ADM_DOCUMENTO_IDENTIDADDTO>();
            // ADM_ESPECIALIDAD
            Mapper.CreateMap<Entidades.ADM_ESPECIALIDAD.ADM_ESPECIALIDAD, TABLAS.ADM_ESPECIALIDAD.ADM_ESPECIALIDADDTO>();
            Mapper.CreateMap<Entidades.ADM_ESPECIALIDAD.ADM_ESPECIALIDADPROFESIONAL, TABLAS.ADM_ESPECIALIDAD.ADM_ESPECIALIDADPROFESIONALDTO>();

            // ADM_TIPO_PROFESIONAL
            Mapper.CreateMap<Entidades.ADM_TIPO_PROFESIONAL.ADM_TIPO_PROFESIONAL, TABLAS.ADM_TIPO_PROFESIONAL.ADM_TIPO_PROFESIONALDTO>();
            // ADM_CONDICION_PROFESIONAL
            Mapper.CreateMap<Entidades.ADM_CONDICION_PROFESIONAL.ADM_CONDICION_PROFESIONAL, TABLAS.ADM_CONDICION_PROFESIONAL.ADM_CONDICION_PROFESIONALDTO>();
            // ADM_DOCUMENTO_AUTORIZACION
            Mapper.CreateMap<Entidades.ADM_DOCUMENTO_AUTORIZACION.ADM_DOCUMENTO_AUTORIZACION, TABLAS.ADM_DOCUMENTO_AUTORIZACION.ADM_DOCUMENTO_AUTORIZACIONDTO>();
            //ADM_PACIENTE
            Mapper.CreateMap<Entidades.ADM_PACIENTE.ADM_PACIENTE, TABLAS.ADM_PACIENTE.ADM_PACIENTEDTO>();
            Mapper.CreateMap<Entidades.ADM_PACIENTE.ADM_PACIENTE_CONSULTA, TABLAS.ADM_PACIENTE.ADM_PACIENTE_CONSULTADTO>();
            //ADM_ATENCION
            Mapper.CreateMap<Entidades.ADM_ATENCION.ADM_ATENCION, TABLAS.ADM_ATENCION.ADM_ATENCIONDTO>();
            Mapper.CreateMap<Entidades.ADM_ATENCION.ADM_ATENCION_ResponseGetAllActives, TABLAS.ADM_ATENCION.ADM_ATENCION_ResponseGetAllActivesDTO>();
            Mapper.CreateMap<Entidades.ADM_ATENCION.ADM_ATENCION_RequestGetAllActive, TABLAS.ADM_ATENCION.ADM_ATENCION_RequestGetAllActiveDTO>();

            //ADM_ESTADO_CIVIL
            Mapper.CreateMap<Entidades.ADM_ESTADO_CIVIL.ADM_ESTADO_CIVIL, TABLAS.ADM_ESTADO_CIVIL.ADM_ESTADO_CIVILDTO>();
            //ADM_GRUPO_SANGUINEO
            Mapper.CreateMap<Entidades.ADM_GRUPO_SANGUINEO.ADM_GRUPO_SANGUINEO, TABLAS.ADM_GRUPO_SANGUINEO.ADM_GRUPO_SANGUINEODTO>();
            //ADM_UBIGEO
            Mapper.CreateMap<Entidades.ADM_UBIGEO.ADM_UBIGEO, TABLAS.ADM_UBIGEO.ADM_UBIGEODTO>();
            //ADM_TIPO_PACIENTE
            Mapper.CreateMap<Entidades.ADM_TIPO_PACIENTE.ADM_TIPO_PACIENTE, TABLAS.ADM_TIPO_PACIENTE.ADM_TIPO_PACIENTEDTO>();
            //ADM_TIPO_ATENCION
            Mapper.CreateMap<Entidades.ADM_TIPO_ATENCION.ADM_TIPO_ATENCION, TABLAS.ADM_TIPO_ATENCION.ADM_TIPO_ATENCIONDTO>();
            //ADM_CONSULTORIO
            Mapper.CreateMap<Entidades.ADM_CONSULTORIO.ADM_CONSULTORIO, TABLAS.ADM_CONSULTORIO.ADM_CONSULTORIODTO>();
            //ADM_DOCUMENTO_PRESTACION
            Mapper.CreateMap<Entidades.ADM_DOCUMENTO_PRESTACION.ADM_DOCUMENTO_PRESTACION, TABLAS.ADM_DOCUMENTO_PRESTACION.ADM_DOCUMENTO_PRESTACIONDTO>();
            //ADM_TIPO_FILIACION
            Mapper.CreateMap<Entidades.ADM_TIPO_AFILIACION.ADM_TIPO_AFILIACION, TABLAS.ADM_TIPO_AFILIACION.ADM_TIPO_AFILIACIONDTO>();
            //ADM_CIE10
            Mapper.CreateMap<Entidades.ADM_CIE10.ADM_CIE10, TABLAS.ADM_CIE10.ADM_CIE10DTO>();
            //ADM_TIPO_CIE10
            Mapper.CreateMap<Entidades.ADM_TIPO_CIE10.ADM_TIPO_CIE10, TABLAS.ADM_TIPO_CIE10.ADM_TIPO_CIE10DTO>();
            //ADM_PROFESIONAL
            Mapper.CreateMap<Entidades.ADM_PROFESIONAL.ADM_PROFESIONAL, TABLAS.ADM_PROFESIONAL.ADM_PROFESIONALDTO>();
            //ADM_TIPO_HOSPITALIZACION
            Mapper.CreateMap<Entidades.ADM_TIPO_HOSPITALIZACION.ADM_TIPO_HOSPITALIZACION, TABLAS.ADM_TIPO_HOSPITALIZACION.ADM_TIPO_HOSPITALIZACIONDTO>();
            //ADM_HABITACION
            Mapper.CreateMap<Entidades.ADM_HABITACION.ADM_HABITACION, TABLAS.ADM_HABITACION.ADM_HABITACIONDTO>();
            //ADM_TIPO_EGRESO
            Mapper.CreateMap<Entidades.ADM_TIPO_EGRESO.ADM_TIPO_EGRESO, TABLAS.ADM_TIPO_EGRESO.ADM_TIPO_EGRESODTO>();
            //ADM_TIPO_AAFILIACION
            Mapper.CreateMap<Entidades.ADM_TIPO_AAFILIACION.ADM_TIPO_AAFILIACION, TABLAS.ADM_TIPO_AAFILIACION.ADM_TIPO_AAFILIACIONDTO>();
            //ADM_DOCUMENTO_AUTORIZACION_REQ
            Mapper.CreateMap<Entidades.ADM_DOCUMENTO_AUTORIZACION.ADM_DOCUMENTO_AUTORIZACION_REQ, TABLAS.ADM_DOCUMENTO_AUTORIZACION.ADM_DOCUMENTO_AUTORIZACION_REQDTO>();
            Mapper.CreateMap<Entidades.ADM_DOCUMENTO_AUTORIZACION.ADM_DOCUMENTO_AUTORIZACION_RES, TABLAS.ADM_DOCUMENTO_AUTORIZACION.ADM_DOCUMENTO_AUTORIZACION_RESDTO>();


            Mapper.CreateMap<Entidades.FAC_DOCUMENTO_PAGO.FAC_DOCUMENTO_PAGO, TABLAS.FAC_DOCUMENTO_PAGO.FAC_DOCUMENTO_PAGODTO>();
            Mapper.CreateMap<Entidades.ADM_FORMA_PAGO.ADM_FORMA_PAGORes, TABLAS.ADM_FORMA_PAGODTO.ADM_FORMA_PAGOResDTO>();


            Mapper.CreateMap<Entidades.ADM_ATENCION.ADM_ATENCION_PendingResponse, TABLAS.ADM_ATENCION.ADM_ATENCION_PendingResponseDTO>();

            Mapper.CreateMap<Entidades.FAC_DOCUMENTO_PAGO.FAC_COMPROBANTEReq, TABLAS.FAC_DOCUMENTO_PAGO.FAC_COMPROBANTEReqDTO>();
            Mapper.CreateMap<Entidades.FAC_DOCUMENTO_PAGO.FAC_COMPROBANTE_Detalle, TABLAS.FAC_DOCUMENTO_PAGO.FAC_COMPROBANTE_DetalleDTO>();

        }

    }
}
