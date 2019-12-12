using SmartDrivingMVCDAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDrivingMVCDAL
{
    public class Facade
    {
        private ActivityRepository activityRepo;
        private ActivityTypeRepository activityTypeRepo;
        private BookingRepository bookingRepo;
        private CustomerRepository customerRepo;
        private StaffRepository staffRepo;
        private BookingEvaluationRepository bookingEvaluationRepo;
        private EvaluationRepository evaluationRepo;
        private EvaluationTypeRepository evaluationTypeRepo;
        private PostalDistrictRepository postalDistrictRepo;
        private RoleRepository roleRepo;
        private VehicleBookingRepository vehicleBookingRepo;
        private VehicleRepository vehicleRepo;


        public VehicleRepository GetVehicleRepository()
        {
            if (vehicleRepo == null)
            {
                vehicleRepo = new VehicleRepository();
            }
            return vehicleRepo;
        }

        public VehicleBookingRepository GetVehicleBookingRepository()
        {
            if (vehicleBookingRepo == null)
            {
                vehicleBookingRepo = new VehicleBookingRepository();
            }
            return vehicleBookingRepo;
        }

        public RoleRepository GetRoleRepository()
        {
            if (roleRepo == null)
            {
                roleRepo = new RoleRepository();
            }
            return roleRepo;
        }

        public PostalDistrictRepository GetPostalDistrict()
        {
            if (postalDistrictRepo == null)
            {
                postalDistrictRepo = new PostalDistrictRepository();
            }
            return postalDistrictRepo;
        }

        public BookingRepository GetBookingRepository()
        {
            if (bookingRepo == null)
            {
                bookingRepo = new BookingRepository();
            }
            return bookingRepo;
        }

        public BookingEvaluationRepository GetBookingEvaluation()
        {
            if (bookingEvaluationRepo == null)
            {
                bookingEvaluationRepo = new BookingEvaluationRepository();
            }
            return bookingEvaluationRepo;
        }

        public ActivityRepository GetActivityRepository()
        {
            if (activityRepo == null)
            {
                activityRepo = new ActivityRepository();
            }
            return activityRepo;
        }

        public ActivityTypeRepository GetActivityTypeRepository()
        {
            if (activityTypeRepo == null)
            {
                activityTypeRepo = new ActivityTypeRepository();
            }
            return activityTypeRepo;
        }

        public CustomerRepository GetCustomerRepository()
        {
            if (customerRepo == null)
            {
                customerRepo = new CustomerRepository();
            }
            return customerRepo;
        }

        public StaffRepository GetStaffRepository()
        {
            if (staffRepo == null)
            {
                staffRepo = new StaffRepository();
            }
            return staffRepo;
        }

        public EvaluationRepository GetEvaluationRepository()
        {
            if (evaluationRepo == null)
            {
                evaluationRepo = new EvaluationRepository();
            }
            return evaluationRepo;
        }

        public EvaluationTypeRepository GetEvaluationTypeRepository()
        {
            if (evaluationTypeRepo == null)
            {
                evaluationTypeRepo = new EvaluationTypeRepository();
            }
            return evaluationTypeRepo;
        }
    }
}
