﻿using ContractConfigurator.Parameters;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContractConfigurator;
using UnityEngine;
using SCANsat;

namespace ContractConfigurator.SCANsat
{
    public class SCANsatCoverageFactory : ParameterFactory
    {
        protected SCANdata.SCANtype scanType;
        protected double coverage;

        public override bool Load(ConfigNode configNode)
        {
            // Load base class
            bool valid = base.Load(configNode);

            valid &= ConfigNodeUtil.ParseValue<double>(configNode, "coverage", ref coverage, this);
            valid &= ConfigNodeUtil.ParseValue<SCANdata.SCANtype>(configNode, "scanType", ref scanType, this);
            valid &= ValidateTargetBody(configNode);

            return valid;
        }

        public override ContractParameter Generate(Contract contract)
        {
            return new SCANsatCoverage(coverage, scanType, targetBody, title);
        }
    }
}
